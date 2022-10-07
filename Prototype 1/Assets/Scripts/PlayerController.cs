using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int wheelsOnGround;
    private float speed;
    private float rpm;
    private float turnSpeed = 25f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    [SerializeField] private float horsePower = 0f;
    [SerializeField] GameObject centerOM;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOM.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * horsePower * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);

            //Rotate vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + " km/h");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
