using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    [SerializeField] Image TimerBarFill;
    [SerializeField] private float MaxGameTime = 60f;
    [SerializeField] GameObject prefabTimer;
    private float TimerValue;
    private bool isInside = false;
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
        TimerValue -= Time.deltaTime;
        UpdateTimerDisplay(TimerValue);
        if (Input.GetMouseButtonUp(0))
        {
            if (isInside)
            {
                TestRecipe(null);
            }
        }
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
        if (true)
        {
            Debug.Log("Correct Recipe");
        }
        else
        {
            Debug.Log("Wrong Recipe");
        }
    }
}
