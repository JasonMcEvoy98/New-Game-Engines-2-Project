using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckArrivalTask : BTNode
{

    IBehaviourAI myAI;

    public CheckArrivalTask(IBehaviourAI _myAI)
    {
        myAI = _myAI;
    }


    public override BTNodeState Evaluate()
    {

        Vector3 agentPosition = myAI.GetAgentTransform().position;
        Vector3 targetPosition = myAI.GetTargetPosition();

        float distance = Vector3.Distance(agentPosition, targetPosition);

        if (distance < 100f)
        {
            return BTNodeState.SUCCESS;
        }
        else
        {
            return BTNodeState.FAILURE;
        }

    }
}
