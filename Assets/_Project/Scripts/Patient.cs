using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    [SerializeField] private Image TimerBarFill;
    [SerializeField] private float MaxGameTime = 60f;
    [SerializeField] private GameObject prefabTimer;
    [SerializeField] private Sprite DeadFace;
    [SerializeField] private Sprite SavedFace;
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
    public void Init(Canvas MainCanvas)
    {
        TimerValue = MaxGameTime;
        GameObject timer = Instantiate(prefabTimer, new Vector3(0,0,0), Quaternion.identity);
        timer.transform.SetParent(MainCanvas.transform, false);
        timer.transform.localScale = new Vector3(1, 1, 1);
        timer.transform.localPosition = new Vector3(600, 350, 0);
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
}
