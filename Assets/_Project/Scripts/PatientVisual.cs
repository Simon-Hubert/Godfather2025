using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PatientVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srBody;
    [SerializeField] private SpriteRenderer srHair;
    [SerializeField] private SpriteRenderer srFace;
    [SerializeField] private SpriteRenderer srClothes;
    [SerializeField] private SpriteRenderer srSickness1;
    [SerializeField] private SpriteRenderer srSickness2;


    [SerializeField] private Sprite[] bodySprites;
    [SerializeField] private Sprite[] hairSprites;
    [SerializeField] private Sprite[] faceSprites;
    [FormerlySerializedAs("skinSprites")] [SerializeField] private Sprite[] clothesSprites;

    private void Awake()
    {
        srBody.sprite = bodySprites[Random.Range(0, bodySprites.Length)];
        srHair.sprite = hairSprites[Random.Range(0, hairSprites.Length)];
        srFace.sprite = faceSprites[Random.Range(0, faceSprites.Length)];
        srClothes.sprite = clothesSprites[Random.Range(0, clothesSprites.Length)];
    }
    public void EditBody(Sprite newBody)
    {
        srBody.sprite = newBody;
    }
    public void EditHair(Sprite newHair)
    {
        srHair.sprite = newHair;
    }
    public void EditClothes(Sprite newSkin)
    {
        srClothes.sprite = newSkin;
    }
    public void EditFace(Sprite newFace)
    {
        srFace.sprite = newFace;
    }

    public void SetSickness1(Sprite sprite) {
        srSickness1.sprite = sprite;
    }
    
    public void SetSickness2(Sprite sprite) {
        srSickness2.sprite = sprite;
    }
    
}
