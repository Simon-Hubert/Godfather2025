using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum AffectedPart {
    None = 0,
    Head = 1 << 0,
    Body = 1 << 1,
    Skin = 1 << 2,
    Hair = 1 << 3
}

[Serializable]
public struct Sickness
{
    public Sprite Visual;
    public string Name;
    public AffectedPart AffectedParts;
}

public class SickGenerator : MonoBehaviour
{
    [SerializeField] private Sickness[] Sicknesses;


    public (Sickness, Sickness) GetRandomSickness()
    {
        AffectedPart parts = AffectedPart.None;
        Sickness sickness1 = Sicknesses[UnityEngine.Random.Range(0, Sicknesses.Length)];
        parts |= sickness1.AffectedParts;
        for (int i = 0; i < 1000; i++)
        {
            Sickness sickness2 = Sicknesses[UnityEngine.Random.Range(0, Sicknesses.Length)];
            if ((parts & sickness2.AffectedParts) == AffectedPart.None)
            {
                parts |= sickness2.AffectedParts;
                return (sickness1, sickness2);
            }
        }
        return (Sicknesses[0], Sicknesses[1]);
    }
}
