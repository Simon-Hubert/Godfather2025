using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srBody;
    [SerializeField] private SpriteRenderer srHair;
    [SerializeField] private SpriteRenderer srFace;
    [SerializeField] private SpriteRenderer srSkin;


    [SerializeField] private Sprite[] bodySprites;
    [SerializeField] private Sprite[] hairSprites;
    [SerializeField] private Sprite[] faceSprites;
    [SerializeField] private Sprite[] skinSprites;

    private void Awake()
    {
        srBody.sprite = bodySprites[Random.Range(0, bodySprites.Length)];
        srHair.sprite = hairSprites[Random.Range(0, hairSprites.Length)];
        srFace.sprite = faceSprites[Random.Range(0, faceSprites.Length)];
        srSkin.sprite = skinSprites[Random.Range(0, skinSprites.Length)];
    }
}
