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
    public void EditBody(Sprite newBody)
    {
        srBody.sprite = newBody;
    }
    public void EditHair(Sprite newHair)
    {
        srHair.sprite = newHair;
    }
    public void EditSkin(Sprite newSkin)
    {
        srSkin.sprite = newSkin;
    }
    public void EditFace(Sprite newFace)
    {
        srFace.sprite = newFace;
    }
}
