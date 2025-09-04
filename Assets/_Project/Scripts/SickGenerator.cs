using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
    public Sprite Visual;
    public string Name;
    public AffectedPart AffectedParts;
}

[Serializable]
public struct Sickness
{
    public Symptom symptom1;
    public Symptom symptom2;
}

public class SickGenerator : MonoBehaviour
{
    [FormerlySerializedAs("Sicknesses")] [SerializeField] private Symptom[] _sicknesses;
    
    public Sickness GetRandomSickness() {
        AffectedPart parts = AffectedPart.None;
        Symptom sickness1 = _sicknesses[UnityEngine.Random.Range(0, _sicknesses.Length)];
        parts |= sickness1.AffectedParts;
        for (int i = 0; i < 1000; i++) {
            Symptom sickness2 = _sicknesses[UnityEngine.Random.Range(0, _sicknesses.Length)];
            if ((parts & sickness2.AffectedParts) == AffectedPart.None) {
                return new Sickness(){symptom1 = sickness1, symptom2 = sickness2};
            }
        }

        return new Sickness(){symptom1 =  _sicknesses[0], symptom2 = _sicknesses[1]};
    }
}