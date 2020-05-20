using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargetVisible : BTNode
{

    IBehaviourAI myAI;


    public IsTargetVisible(IBehaviourAI _myAI)
    {
        myAI = _myAI;
    }

    public override BTNodeState Evaluate()
    {
        if (myAI.GetTarget() == null) return BTNodeState.FAILURE;

        RaycastHit hit;

        if(Physics.Raycast(myAI.GetTransform().position, myAI.GetTransform().forward, out hit, 1000f))
        {
            if(hit.collider.transform.root.gameObject == myAI.GetTarget())
            {
                return BTNodeState.SUCCESS;
            }
        }

        else
        {
            return BTNodeState.FAILURE;
        }
        return BTNodeState.FAILURE;
    }
}
