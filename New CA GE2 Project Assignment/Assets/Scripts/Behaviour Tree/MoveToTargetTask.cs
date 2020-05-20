using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetTask : BTNode
{
    IBehaviourAI myAI;
    Transform agentTransform;
    Vector3 targetPosition;
    float range;
    event InputEventFloat ForwardEvent;

    public MoveToTargetTask (IBehaviourAI _myAI, float _range, InputEventFloat _forwardEvent)
    {
        myAI = _myAI;
        range = _range;
        ForwardEvent = _forwardEvent;
    }

    public override BTNodeState Evaluate()
    {

        Vector3 agentPosition = myAI.GetAgentTransform().position;
        targetPosition = myAI.GetTargetPosition();

        float distance = Vector3.Distance(agentPosition, targetPosition);
        float thrust = distance / range;
        if (ForwardEvent != null) ForwardEvent(thrust);

        return BTNodeState.SUCCESS;

    }
}
