using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Ingredient : IngredientObject
{
    [ShowNonSerializedField] private int _id;
    public int Id => _id;
    

    public void Init(IngredientData data, int id) {
        _id = id;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = data.Sprite;
    }
    public void AddInitialVelocity(Vector2 initialVelocity) {
        GetComponent<Rigidbody2D>().velocity = initialVelocity;
    }
}
