using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject RandomPatient;
    [SerializeField] private Transform PatientTimerParent;
    [SerializeField] private SickGenerator sickGenerator;

    [SerializeField] private LootBox lootBox;

    [SerializeField] private Background _bg;
    
    void Start()
    {
        CreatePatient();
    }

    public void CreatePatient()
    {
        Patient Patient = Instantiate(RandomPatient, transform).GetComponent<Patient>();
        Patient.Init(PatientTimerParent, _bg);
        Sickness sickness = sickGenerator.GetRandomSickness();
        Patient.SetSickness(sickness);
        lootBox.Open(sickness);
    }
}
