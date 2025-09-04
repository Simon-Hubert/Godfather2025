using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Ingredient : IngredientObject
{
    [ShowNonSerializedField] private int _id;
    private bool _isInit;

    public bool IsInit => _isInit;
    public int Id => _id;
    

    public void Init(IngredientData data, int id) {
        _id = id;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = data.Sprite;
        _isInit = true;
    }

    private void Start() {
        if (!_isInit) {
            Debug.Log("Ingredient not created via Factory");
        }
    }
}
