using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : BTNode
{
    private List<BTNode> myNodes = new List<BTNode>();

    public Sequence (List<BTNode> nodes)
    {
        myNodes = nodes;
    }

    public override BTNodeState Evaluate()
    {
        bool childRunning = false;

        foreach (BTNode node in myNodes)
        {
            switch (node.Evaluate())
            {
                case BTNodeState.FAILURE:
                    currentNodeState = BTNodeState.FAILURE;
                    return currentNodeState; 

                case BTNodeState.SUCCESS:
                    continue;

                case BTNodeState.RUNNING:
                    childRunning = true;
                    continue;

                default:
                    currentNodeState = BTNodeState.SUCCESS;
                    return currentNodeState;

            }
        }
        currentNodeState = childRunning ? BTNodeState.RUNNING : BTNodeState.SUCCESS;
        return currentNodeState;


    }
}
