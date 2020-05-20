using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour, IControllerInput, IBehaviourAI
{
    public event InputEvent FireEvent;
    public event InputEventFloat ForwardEvent;
    public event InputEventFloat YawEvent;
    public event InputEventFloat PitchEvent;
    public event InputEventFloat RollEvent;
    public event InputEventFloat SideStrafeEvent;
    public event InputEventFloat VerticalStrafeEvent;
    public event InputEventFloat SlideEvent;
    public event InputEventVector3 TurnEvent;

    public Vector3 myTargetPosition = Vector3.zero;

    //behaviours
    public Selector rootAI;
    public Sequence CheckArrivalSequence;
    public Sequence MoveSequence;
    public Sequence DecideToAttack;
    public Selector SelectTargetType;
    bool avoiding = false;
    public float avoidDistance = 100f;
    public LayerMask avoidLayerMask;
    Vector3 temporaryTarget;
    Vector3 savedTargetPosition;

    GameObject target = null;
    public string enemyFaction = "PlayerFaction";

    // Start is called before the first frame update
    void Start()
    {
        DecideToAttack = new Sequence(new List<BTNode>
        {
            new RandomChanceCondition(1, 100, 10),
            new FindNewTargetTask(this, enemyFaction)
        });

        SelectTargetType = new Selector(new List<BTNode>
        {
            DecideToAttack,
            new FindWanderPointTask (this, 500f),
        });

        CheckArrivalSequence = new Sequence(new List<BTNode>
        {
            new CheckArrivalTask(this),
            new FindWanderPointTask (this, 500f),
        });

        MoveSequence = new Sequence(new List<BTNode>
        {
            new ObstacleAvoidance (this, avoidDistance, TurnEvent, avoidLayerMask),
            new MoveToTargetTask(this, 100f, ForwardEvent),
            new IsTargetVisible (this),
            new FireWeaponTask(this, FireEvent)
        });

        rootAI = new Selector(new List<BTNode>
        {
            CheckArrivalSequence,
            MoveSequence,
        });

        new FindWanderPointTask(this, 500f);

    }

    // Update is called once per frame
    void Update()
    {
        rootAI.Evaluate();
    }

    public Vector3 SetTargetPosition(Vector3 targetPosition)
    {
       
        myTargetPosition = targetPosition;
        return myTargetPosition;

    }

    public Transform GetAgentTransform()
    {
        return transform;
    }

    public Vector3 GetTargetPosition()
    {
        if (target != null) return target.transform.position;

        return myTargetPosition;
    }

    public GameObject SetTarget(GameObject newTarget)
    {
        target = newTarget;
        return target;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public bool GetAvoidFlag()
    {
        return avoiding;
    }

    public Vector3 SetTempTarget(Vector3 position)
    {
        avoiding = true;
        temporaryTarget = position;
        savedTargetPosition = myTargetPosition;
        return position;
    }

    public Vector3 ReturnToSaveTarget()
    {
        avoiding = false;
        temporaryTarget = Vector3.zero;
        myTargetPosition = savedTargetPosition;

        return savedTargetPosition;
    }
}

