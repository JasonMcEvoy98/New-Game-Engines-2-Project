using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviourAI 
{
    Vector3 SetTargetPosition(Vector3 targetPosition);
    Transform GetAgentTransform();
    Vector3 GetTargetPosition();
    GameObject SetTarget(GameObject gameObject);
    GameObject GetTarget();
    Transform GetTransform();
    bool GetAvoidFlag();
    Vector3 SetTempTarget(Vector3 position);
    Vector3 ReturnToSaveTarget();
}
