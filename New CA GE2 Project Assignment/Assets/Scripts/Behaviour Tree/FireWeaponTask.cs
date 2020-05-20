using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeaponTask : BTNode
{

    IBehaviourAI myAI;
    InputEvent fireWeaponEvent;

    public FireWeaponTask(IBehaviourAI _myAI, InputEvent _fireWeaponEvent)
    {
        myAI = _myAI;
        fireWeaponEvent = _fireWeaponEvent;
    }
    public override BTNodeState Evaluate()
    {
        if (fireWeaponEvent !=null)
        {
            fireWeaponEvent();

            return BTNodeState.SUCCESS;
        }
        else
        {
            return BTNodeState.FAILURE;
        }
    }

}
