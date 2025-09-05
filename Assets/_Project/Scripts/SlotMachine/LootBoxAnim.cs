using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootBoxAnim : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("Open");
    [SerializeField] private Animator _anim;
    [SerializeField] private UnityEvent _onLootBoxOpen;

    public void Play() {
        _anim.SetTrigger(Open);
    }
    
    public void OnLootBoxOpen() {
        _onLootBoxOpen?.Invoke();
    }
}
