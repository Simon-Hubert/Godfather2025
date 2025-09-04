using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] Image TimerBarFill;
    [SerializeField] private float MaxGameTime = 360f;
    private float TimerValue;
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
    }
}
