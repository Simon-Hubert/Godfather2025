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
        Patient Patient = Instantiate(RandomPatient, transform).GetComponent<Patient>();
        Patient.Init(MainCanva);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
