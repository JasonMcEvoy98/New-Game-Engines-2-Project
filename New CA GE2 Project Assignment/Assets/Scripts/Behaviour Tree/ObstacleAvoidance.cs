using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : BTNode
{
    IBehaviourAI myAI;
    Transform agentTransform;
    float avoidDistance;
    LayerMask avoidlayerMask;
    event InputEventVector3 TurnEvent;

    public ObstacleAvoidance(IBehaviourAI _myAI, float _avoidDistance, InputEventVector3 _turnEvent, LayerMask  _avoidlayerMask)
    {
        myAI = _myAI;
        avoidDistance = _avoidDistance;
        TurnEvent = _turnEvent;
        avoidlayerMask = _avoidlayerMask;
    }


    public override BTNodeState Evaluate()
    {

        agentTransform = myAI.GetAgentTransform();
        Vector3[] rayDirections =
        {
            agentTransform.forward,
            Helper.GetDirectionFromAngleInDegrees(10f, agentTransform.forward, agentTransform.right),
            Helper.GetDirectionFromAngleInDegrees(-10f, agentTransform.forward, agentTransform.right),
            Helper.GetDirectionFromAngleInDegrees(10f, agentTransform.forward, agentTransform.up),
            Helper.GetDirectionFromAngleInDegrees(-10f, agentTransform.forward, agentTransform.up),
            (agentTransform.forward + agentTransform.right). normalized,
            (agentTransform.forward - agentTransform.right). normalized,
            (agentTransform.forward + agentTransform.up). normalized,
            (agentTransform.forward - agentTransform.up). normalized,
            (agentTransform.right). normalized,
            (-agentTransform.right). normalized,
            (agentTransform.up). normalized,
            (-agentTransform.up). normalized,
        };

        DrawRays(rayDirections);

        RaycastHit hit;

        if (Physics.Raycast(agentTransform.position, rayDirections[0], out hit, avoidDistance, avoidlayerMask) ||
            Physics.Raycast(agentTransform.position, rayDirections[1], out hit, avoidDistance, avoidlayerMask) ||
          Physics.Raycast(agentTransform.position, rayDirections[2], out hit, avoidDistance, avoidlayerMask) ||
             Physics.Raycast(agentTransform.position, rayDirections[3], out hit, avoidDistance, avoidlayerMask) ||
              Physics.Raycast(agentTransform.position, rayDirections[4], out hit, avoidDistance, avoidlayerMask))
        {
            for (int i = 5; i < rayDirections.Length; i++)
            {
                bool goodTurn = CheckTurn(rayDirections[i]);
                if (goodTurn) return BTNodeState.SUCCESS;
            }

            return BTNodeState.SUCCESS;

        }
        Vector3 agentPosition = agentTransform.position;
        Vector3 targetPosition = myAI.GetTargetPosition();
        Vector3 desiredHeading = (targetPosition - agentPosition);

        
        TurnEvent(desiredHeading.x, desiredHeading.y, desiredHeading.z);

        return BTNodeState.SUCCESS;
    }

    private bool CheckTurn (Vector3 rayDirection)
    {
        RaycastHit hit;

        if(!Physics.Raycast (agentTransform.position, rayDirection * (avoidDistance /4), out hit, avoidDistance, avoidlayerMask))
        {
            Vector3 newHeading = rayDirection;
            Vector3 newTarget = -agentTransform.position + (newHeading * (avoidDistance / 4));
            myAI.SetTempTarget(newTarget);
            if (TurnEvent != null) TurnEvent(newHeading.x, newHeading.y, newHeading.z);
            return true;
        }
        return false;

    }

    private void DrawRays (Vector3[] rayDirections)
    {
        foreach (Vector3 dir in rayDirections)
        {
            Debug.DrawRay(agentTransform.position, dir * avoidDistance, Color.blue);
        }
    }

    
}
