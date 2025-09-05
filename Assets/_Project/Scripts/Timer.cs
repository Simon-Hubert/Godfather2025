using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image timerBarFill;
    [SerializeField] private Image timerBarOutline;

    public Image TimerBarFill => timerBarFill;
    public Image TimerBarOutline => timerBarOutline;
}
