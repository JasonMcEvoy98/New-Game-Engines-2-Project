using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public PlayerInput playerInput;
    public float forwardThrustPower = 10f;
    public float yawSpeed = 10f;
    public float pitchSpeed = 10f;
    public float rollSpeed = 10f;
    public float invertModifier = -1;

    Rigidbody myrigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();

        playerInput.ForwardEvent += ForwardThrust;
        playerInput.YawEvent += YawMovement;
        playerInput.PitchEvent += PitchMovement;
        playerInput.RollEvent += RollMovement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForwardThrust(float thrust)
    {
        myrigidbody.AddForce(gameObject.transform.forward * thrust * forwardThrustPower * Time.deltaTime);
    }

    public void YawMovement(float yaw)
    {
        myrigidbody.AddTorque(gameObject.transform.up * yaw * yawSpeed * Time.deltaTime);
    }
    public void PitchMovement(float pitch)
    {
        myrigidbody.AddTorque(gameObject.transform.right * pitch * invertModifier * pitchSpeed * Time.deltaTime);
    }
    public void RollMovement(float roll)
    {
        myrigidbody.AddTorque(gameObject.transform.forward * roll * rollSpeed * Time.deltaTime);
    }
}
