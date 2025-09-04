using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    [SerializeField] private Image TimerBarFill;
    [SerializeField] private float MaxGameTime = 60f;
    [SerializeField] private GameObject prefabTimer;
    [SerializeField] private Sprite DeadFace;
    [SerializeField] private Sprite SavedFace;
    [SerializeField] private PatientVisual visual;

    [SerializeField] private Sickness _sickness;
    private float TimerValue;
    private bool isInside = false;
    private bool isActive = true;
    
    public void UpdateTimerDisplay(float RemainingTime)
    {
        if (TimerBarFill)
        {
            TimerBarFill.fillAmount = RemainingTime / MaxGameTime;
        }
    }
    public void Init(Transform timerParent)
    {
        TimerValue = MaxGameTime;
        GameObject timer = Instantiate(prefabTimer, new Vector3(0,0,0), Quaternion.identity);
        timer.transform.SetParent(timerParent, false);
        TimerBarFill = timer.GetComponent<Timer>().TimerBarFill;
    }
    void Update()
    {
        if (isActive)
        {
            TimerValue -= Time.deltaTime;
        }
        UpdateTimerDisplay(TimerValue);
        if (Input.GetMouseButtonUp(0))
        {
            if (isInside)
            {
                TestRecipe(null);
            }
        }
        if (TimerValue <= 0f)
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
        }
        else
        {
            GetComponent<PatientVisual>().EditFace(DeadFace);
        }
        yield return new WaitForSeconds(2.5f);
        GetComponentInParent<PatientManager>().CreatePatient();
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        isInside = true;
    }
    void OnTriggerExit(Collider other)
    {
        isInside = false;
    }
    void TestRecipe(Collider other)
    {
        //check si c'est une recette
        int gain = 0;
        if (true)
        {
            gain = 1;
            //ajouter du score
        }
        isActive = false;
        StartCoroutine(NextPatient(gain));
    }
    
    public void SetSickness(Sickness sickness) {
        switch (sickness.symptom1.AffectedParts) {
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
