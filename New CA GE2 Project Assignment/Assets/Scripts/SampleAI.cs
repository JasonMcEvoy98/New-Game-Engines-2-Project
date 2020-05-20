using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAI : MonoBehaviour, IControllerInput
{
    public event InputEvent FireEvent;
    public event InputEventFloat ForwardEvent;
    public event InputEventFloat YawEvent;
    public event InputEventFloat PitchEvent;
    public event InputEventFloat RollEvent;
    public event InputEventFloat SideStrafeEvent;
    public event InputEventFloat VerticalStrafeEvent;
    public event InputEventFloat SlideEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
