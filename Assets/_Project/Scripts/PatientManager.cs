using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject RandomPatient;
    [SerializeField] private Canvas MainCanva;
    [SerializeField] private Patient PatientTimer;
    void Start()
    {
        CreatePatient();
    }

    public void CreatePatient()
    {
        Patient Patient = Instantiate(RandomPatient, transform).GetComponent<Patient>();
        Patient.Init(MainCanva);
    }
}
