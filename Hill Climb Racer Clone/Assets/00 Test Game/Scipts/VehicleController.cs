using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private float vehicleSpeed = 150f;

    [SerializeField] private Rigidbody2D vehicleRB;
    [SerializeField] private float vehicleRotationSpeed = 300f;

    private float moveInput;


    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }


    private void FixedUpdate()
    {
        frontTireRB.AddTorque(-moveInput * vehicleSpeed * Time.fixedDeltaTime);
        backTireRB.AddTorque(-moveInput * vehicleSpeed * Time.fixedDeltaTime);
        vehicleRB.AddTorque(moveInput * vehicleRotationSpeed * Time.fixedDeltaTime);
    }
}
