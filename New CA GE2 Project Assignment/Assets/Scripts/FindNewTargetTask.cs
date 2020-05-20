using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FindNewTargetTask : BTNode
{
    IBehaviourAI myAI;
    string enemyFaction;


    public FindNewTargetTask(IBehaviourAI _myAI, string _enemyFaction)
    {
        myAI = _myAI;
        enemyFaction = _enemyFaction;


    }

    public override BTNodeState Evaluate()
    {

        GameObject[] targets = GameObject.FindGameObjectsWithTag(enemyFaction);
        

       if (targets.Length > 0)
        {

            int randomChoice = Random.Range(0, targets.Length);
            myAI.SetTarget(targets[randomChoice]);
            Debug.Log("Found target:" + targets[randomChoice].name);
            return BTNodeState.SUCCESS;
        }
        else
        {
            Debug.Log("failed to find target");
            return BTNodeState.FAILURE;
        }
    }

}