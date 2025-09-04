using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct IngredientData
{
    [SerializeField] private string _name;
    [SerializeField] private int _rarity;
    [SerializeField] private Sprite _sprite;

    public string Name => _name;
    public int Rarity => _rarity;
    public Sprite Sprite => _sprite;
}
