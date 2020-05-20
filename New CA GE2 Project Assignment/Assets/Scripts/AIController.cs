using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour, IControllerInput, IBehaviourAI
{
    public event InputEvent FireEvent;
    public event InputEventFloat ForwardEvent;
    public event InputEventFloat YawEvent;
    public event InputEventFloat PitchEvent;
    public event InputEventFloat RollEvent;
    public event InputEventFloat SideStrafeEvent;
    public event InputEventFloat VerticalStrafeEvent;
    public event InputEventFloat SlideEvent;
    public event InputEventVector3 TurnEvent;

    public Vector3 myTargetPosition = Vector3.zero;

    //behaviours
    public Selector rootAI;
    public Sequence CheckArrivalSequence;
    public Sequence MoveSequence;

    // Start is called before the first frame update
    void Start()
    {
        CheckArrivalSequence = new Sequence(new List<BTNode>
        {
            new CheckArrivalTask(this),
            new FindWanderPointTask (this, 500f),
        });

        MoveSequence = new Sequence(new List<BTNode>
        {
            new TurnToTargetTask(this, TurnEvent),
            new MoveToTargetTask(this, 100f, ForwardEvent)
        });

        rootAI = new Selector(new List<BTNode>
        {
            CheckArrivalSequence,
            MoveSequence,
        });

        new FindWanderPointTask(this, 500f);

    }

    // Update is called once per frame
    void Update()
    {
        rootAI.Evaluate();
    }

    public Vector3 SetTargetPosition(Vector3 targetPosition)
    {
        myTargetPosition = targetPosition;
        return myTargetPosition;

    }

    public Transform GetAgentTransform()
    {
        return transform;
    }

    public Vector3 GetTargetPosition()
    {
        return myTargetPosition;
    }
}

