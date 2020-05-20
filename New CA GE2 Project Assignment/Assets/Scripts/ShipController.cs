using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    IControllerInput playerInput;
    public GameObject pilot;
    public float forwardThrustPower = 10f;
    public float yawSpeed = 10f;
    public float pitchSpeed = 10f;
    public float rollSpeed = 10f;
   

    Rigidbody myRigidbody;
    float originalDrag;

    // Start is called before the first frame update
    void Start()
    {
        if (pilot)
        {
            playerInput = pilot.GetComponent<IControllerInput>();
        }

        myRigidbody = GetComponent<Rigidbody>();
        originalDrag = myRigidbody.drag;

        playerInput.ForwardEvent += ForwardThrust;
        playerInput.YawEvent += YawMovement;
        playerInput.PitchEvent += PitchMovement;
        playerInput.RollEvent += RollMovement;
        playerInput.VerticalStrafeEvent += VerticalStrafeMovement;
        playerInput.SideStrafeEvent += SideStrafeMovement;
        playerInput.SlideEvent += EnableSlide;

    }

    private void EnableSlide (float slide)
    {
        if (slide > 0) myRigidbody.drag = 0; else myRigidbody.drag = originalDrag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForwardThrust(float thrust)
    {
        myRigidbody.AddForce(gameObject.transform.forward * thrust * forwardThrustPower * Time.deltaTime);
    }

    public void SideStrafeMovement (float thrust)
    {
        myRigidbody.AddForce(gameObject.transform.right * thrust * forwardThrustPower * Time.deltaTime);
    }
    public void VerticalStrafeMovement(float thrust)
    {
        myRigidbody.AddForce(gameObject.transform.up * thrust * forwardThrustPower * Time.deltaTime);
    }

    public void YawMovement(float yaw)
    {
        myRigidbody.AddTorque(gameObject.transform.up * yaw * yawSpeed * Time.deltaTime);
    }
    public void PitchMovement(float pitch)
    {
        myRigidbody.AddTorque(gameObject.transform.right * pitch  * pitchSpeed * Time.deltaTime);
    }
    public void RollMovement(float roll)
    {
        myRigidbody.AddTorque(gameObject.transform.forward * roll * rollSpeed * Time.deltaTime);
    }
}
