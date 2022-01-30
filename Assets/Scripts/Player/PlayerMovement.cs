using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform camTarget;
    
    PlayerManager playerManager;

    Rigidbody rb;
    public Vector2 moveInput;
    Vector2 camInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerManager = GetComponent<PlayerManager>();
        moveInput = camInput = Vector2.zero;
    }

    public void OnMovement(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnCamera(InputAction.CallbackContext context)
    {
        camInput = context.ReadValue<Vector2>() * GameManager.instance.config.camSensitivity;
    }

    void UpdateCamera()
    {
        if (camInput.magnitude == 0) return;
        camTarget.rotation *= Quaternion.AngleAxis(camInput.x * Time.deltaTime, Vector3.up);
        camTarget.rotation *= Quaternion.AngleAxis(-camInput.y * Time.deltaTime, Vector3.right);

        var angles = camTarget.localEulerAngles;
        angles.z = 0;

        var angle = angles.x;
        if (angle > 180 && angle < 330) angles.x = 330;
        else if (angle < 180 && angle > 30) angles.x = 30;

        camTarget.localEulerAngles = angles;
    }

    private void Update()
    {
        UpdateCamera();
    }

    private void FixedUpdate()
    {
        var dir = (camTarget.forward * moveInput.y + camTarget.right * moveInput.x); dir.y = 0; dir.Normalize();
        
        if(playerManager && playerManager.activeForm)
        {
            playerManager.activeForm.SetAnimationBool("running", dir.magnitude > 0);
        }
        if (dir.magnitude == 0) return;

        rb.position += playerManager.samurai.stats.MovementSpeed * Time.fixedDeltaTime * dir;
        playerManager.activeForm.transform.rotation = Quaternion.LookRotation(dir);
    }

}
