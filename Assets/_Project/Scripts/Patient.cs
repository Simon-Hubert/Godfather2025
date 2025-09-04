using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    [SerializeField] Image TimerBarFill;
    [SerializeField] private float MaxGameTime = 60f;
    private float TimerValue;
    private bool isInside = false;
    public void UpdateTimerDisplay(float RemainingTime)
    {
        TimerBarFill.fillAmount = RemainingTime / MaxGameTime;
    }
    void Start()
    {
        TimerValue = MaxGameTime;
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
