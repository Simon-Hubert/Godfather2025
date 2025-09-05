using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    [SerializeField] private Image TimerBarFill;
    [SerializeField] private Image TimerBarOutline;
    [SerializeField] private float MaxGameTime = 60f;
    [SerializeField] private GameObject prefabTimer;
    [SerializeField] private Sprite DeadFace;
    [SerializeField] private Sprite SavedFace;
    [SerializeField] private PatientVisual visual;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveThreshold = 0.01f;
    private Vector3 lastPosition;
    private bool lastIsMoving;

    [SerializeField] private Sickness _sickness;

    private Background _background;
    
    private float TimerValue;
    private Solution insideSol;
    private bool isActive = true;

    void Start()
    {
        if (animator == null) animator = GetComponentInChildren<Animator>();
        lastPosition = transform.position;
    }
    public void UpdateTimerDisplay(float RemainingTime)
    {
        if (TimerBarFill)
        {
            TimerBarFill.fillAmount = RemainingTime / MaxGameTime;
        }
        if (RemainingTime / MaxGameTime < 0.4f)
        {
            if (TimerBarOutline)
            {
                TimerBarOutline.color = Color.red;
            }
        }
        else
        {
            if (TimerBarOutline)
            {
                TimerBarOutline.color = new Color32(179, 140, 70, 255);
            }
        }
    }
    public void Init(Transform timerParent, Background background)
    {
        TimerValue = MaxGameTime;
        GameObject timer = Instantiate(prefabTimer, new Vector3(0, 0, 0), Quaternion.identity);
        timer.transform.SetParent(timerParent, false);
        TimerBarFill = timer.GetComponent<Timer>().TimerBarFill;
        TimerBarOutline = timer.GetComponent<Timer>().TimerBarOutline;
        _background = background;
    }
    
    void Update()
    {
        Vector3 delta = transform.position - lastPosition;
        float speed = delta.magnitude / Mathf.Max(Time.deltaTime, 1e-6f);
        bool isMoving = speed > moveThreshold;

        if (animator != null && isMoving != lastIsMoving)
        {
            animator.SetBool("isMoving", isMoving);
            lastIsMoving = isMoving;
        }

        lastPosition = transform.position;
        if (isActive)
        {
            TimerValue -= Time.deltaTime;
        }
        UpdateTimerDisplay(TimerValue);
        if (Input.GetMouseButtonUp(0))
        {
            if (insideSol)
            {
                TestRecipe();
            }
        }
        if (TimerValue <= 0f && isActive)
        {
            isActive = false;
            StartCoroutine(NextPatient(0));
        }
        
    }
    IEnumerator NextPatient(int gain)
    {
        if (gain > 0)
        {
            GetComponent<PatientVisual>().EditFace(SavedFace);
            ScoreManager.Instance?.AddScore();
            AudioManager.Instance?.PlaySFX(3);
        }
        else
        {
            GetComponent<PatientVisual>().EditFace(DeadFace);
            AudioManager.Instance?.PlaySFX(2);
        }
        yield return new WaitForSeconds(2.5f);
        GetComponentInParent<PatientManager>().CreatePatient();
        StopFanta();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Solution")) {
            insideSol = other.GetComponent<Solution>();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Solution")) {
            insideSol = null;
        }
    }

    void TestRecipe()
    {
        int gain = 0;
        if (insideSol.diseaseId == _sickness.DiseaseId)
        {
            gain = 1;
        }
        isActive = false;
        if (insideSol.isFantaDeFrancko) {
            StartFanta();
        }
        Destroy(insideSol.gameObject);
        StartCoroutine(NextPatient(gain));
    }
    
    private void StartFanta() {
        _background.StartFanta();
    }
    
    private void StopFanta() {
        _background.EndFanta();
    }


    public void SetSickness(Sickness sickness) {
        switch (sickness.symptom1.AffectedParts) {
            case AffectedPart.Body:
                visual.EditSkin(sickness.symptom1.Visual);
                break;
            case AffectedPart.Head:
                visual.EditFace(sickness.symptom1.Visual);
                break;
            case AffectedPart.Skin:
                visual.EditBody(sickness.symptom1.Visual);
                break;
            default:
                visual.SetSickness1(sickness.symptom1.Visual);
                break;
        }
        
        switch (sickness.symptom2.AffectedParts) {
            case AffectedPart.Body:
                visual.EditSkin(sickness.symptom2.Visual);
                break;
            case AffectedPart.Head:
                visual.EditFace(sickness.symptom2.Visual);
                break;
            case AffectedPart.Skin:
                visual.EditBody(sickness.symptom2.Visual);
                break;
            default:
                visual.SetSickness2(sickness.symptom2.Visual);
                break;
        }

        _sickness = sickness;
    }
}
