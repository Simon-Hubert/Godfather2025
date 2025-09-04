using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenMedikit();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SendItem1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SendItem2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SendItem3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SendItem4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SendItem5();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TurnPageBackward();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnPageForward();
        }
    }
    void OpenMedikit()
    {

    }
    void SendItem1()
    {

    }
    void SendItem2()
    {

    }
    void SendItem3()
    {

    }
    void SendItem4()
    {

    }
    void SendItem5()
    {

    }
    void TurnPageBackward()
    {

    }
    void TurnPageForward()
    {

    }
}