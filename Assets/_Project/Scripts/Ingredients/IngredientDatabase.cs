using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IngredientData")]
public class IngredientDatabase : ScriptableObject
{
    [SerializeField] private IngredientData[] _data;

    public IngredientData[] Data => _data;
}
