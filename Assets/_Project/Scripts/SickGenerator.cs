using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Flags]
public enum AffectedPart
{
    None = 0,
    Head = 1 << 0,
    Body = 1 << 1,
    Skin = 1 << 2,
    Nose = 1 << 3
}

[Serializable]
public struct Symptom
{
    public Sprite[] _visuals;
    public Sprite Visual => _visuals[Random.Range(0, _visuals.Length)];

    public AffectedPart AffectedParts;
    
}

[Serializable]
public struct Sickness
{
    public Symptom symptom1;
    public Symptom symptom2;

    public int DiseaseId;

    public SORecipe Recipe1;
    public SORecipe Recipe2;
    public SORecipe Recipe3;
}

public class SickGenerator : MonoBehaviour
{
    [SerializeField] private Sickness[] _sicknesses;
    
    public Sickness GetRandomSickness() {
        return _sicknesses[Random.Range(0, _sicknesses.Length)];
    }
}