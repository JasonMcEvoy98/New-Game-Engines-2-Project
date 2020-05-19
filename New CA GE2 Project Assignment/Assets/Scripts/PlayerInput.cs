using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{

    public event EventManager.InputEventFloat ForwardEvent;
    public event EventManager.InputEventFloat YawEvent;
    public event EventManager.InputEventFloat PitchEvent;
    public event EventManager.InputEventFloat RollEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetKeyboardInput();
    }

    void GetKeyboardInput()
    {
        if (ForwardEvent != null)
        {
            if (Input.GetAxis("Throttle") != 0) ForwardEvent(Input.GetAxis("Throttle"));
        }
        if (YawEvent != null)
        {
            if (Input.GetAxis("Horizontal") != 0) YawEvent(Input.GetAxis("Horizontal"));
        }
        if (PitchEvent != null)
        {
            if (Input.GetAxis("Vertical") != 0) PitchEvent(Input.GetAxis("Vertical"));
        }
        if (RollEvent != null)
        {
            if (Input.GetAxis("Roll") != 0) RollEvent(Input.GetAxis("Roll"));
        }

    }

}
