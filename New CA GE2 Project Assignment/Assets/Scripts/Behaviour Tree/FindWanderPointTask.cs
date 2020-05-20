using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWanderPointTask : BTNode
{
    float range;
    IBehaviourAI myAI;

    public FindWanderPointTask(IBehaviourAI _myAI, float _range)
    {
        range = _range;
        myAI = _myAI;
    }

    public override BTNodeState Evaluate()
    {
        myAI.SetTargetPosition (Random.insideUnitSphere* range);

        return BTNodeState.SUCCESS;
    }

}
