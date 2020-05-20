using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{

    public event EventManager.InputEventFloat ForwardEvent;
    public event EventManager.InputEventFloat YawEvent;
    public event EventManager.InputEventFloat PitchEvent;
    public event EventManager.InputEventFloat RollEvent;
    public event EventManager.InputEventFloat SideStrafeEvent;
    public event EventManager.InputEventFloat VerticalStrafeEvent;

    public float deadZoneRadius = .2f;
    public float invertModifier = -1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetKeyboardInput();
        GetMouseInput();
    }

    void GetKeyboardInput()
    {
        if (ForwardEvent != null)
        {
            if (Input.GetAxis("Vertical") != 0) ForwardEvent(Input.GetAxis("Vertical"));
        }
        if (SideStrafeEvent != null)
        {
            if (Input.GetAxis("Horizontal") != 0) SideStrafeEvent(Input.GetAxis("Horizontal"));
        }
        if (VerticalStrafeEvent != null)
        {
            if (Input.GetAxis("VerticalStrafe") != 0) VerticalStrafeEvent(Input.GetAxis("VerticalStrafe"));
        }
        if (RollEvent != null)
        {
            if (Input.GetAxis("Roll") != 0) RollEvent(Input.GetAxis("Roll"));
        }
    }

    void GetMouseInput()
    {

        Vector3 mousePosition = Input.mousePosition;

        float yaw = (mousePosition.x - (Screen.width * .5f)) / (Screen.width * .5f);
        if (Mathf.Abs(yaw) < deadZoneRadius) yaw = 0;

        if (YawEvent != null)
        {
            if (yaw != 0) YawEvent(yaw);
        }

        float pitch = (mousePosition.y - (Screen.height * .5f)) / (Screen.height * .5f) * invertModifier;
        if (Mathf.Abs(pitch) < deadZoneRadius) pitch = 0;

        if (PitchEvent != null)
        {
            if (pitch != 0) PitchEvent(pitch);
        }
    }

}
