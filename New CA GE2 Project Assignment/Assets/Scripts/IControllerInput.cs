using System;

public delegate void InputEvent();
public delegate void InputEventFloat(float value);

public interface IControllerInput
{
    Action<float, float, float> TurnEvent { get; set; }

    event InputEvent FireEvent;
    event InputEventFloat ForwardEvent;
    event InputEventFloat YawEvent;
    event InputEventFloat PitchEvent;
    event InputEventFloat RollEvent;
    event InputEventFloat SideStrafeEvent;
    event InputEventFloat VerticalStrafeEvent;
    event InputEventFloat SlideEvent;
    //event InputEventFloat TurnEvent;
}
