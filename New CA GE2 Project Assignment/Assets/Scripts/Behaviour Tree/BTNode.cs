using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BTNode : MonoBehaviour
{
    protected BTNodeState currentNodeState;

    public BTNodeState nodeState
    {
        get { return currentNodeState; }
    }
    public BTNode() { }

    public abstract BTNodeState Evaluate();
}
