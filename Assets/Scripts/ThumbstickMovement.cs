using UnityEngine;
using System.Collections;

public class ThumbstickMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float verticalSpeed = 2.0f;
    private OVRCameraRig cameraRig;
    private CharacterController characterController;
    public float playerHeight = 1.8f;

    void Start()
    {
        cameraRig = GetComponent<OVRCameraRig>();

        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }

        characterController.radius = 0.3f;
        characterController.height = playerHeight;
        characterController.center = new Vector3(0f, playerHeight / 2, 0f);
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        if (thumbstickInput.magnitude > 0.1f)
        {
            Vector3 horizontalMove = cameraRig.centerEyeAnchor.transform.TransformDirection(new Vector3(thumbstickInput.x, 0, thumbstickInput.y));
            horizontalMove.y = 0;
            moveDirection += horizontalMove.normalized * movementSpeed;
        }

        float leftTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (leftTriggerValue > 0.1f)
        {
            moveDirection += Vector3.up * verticalSpeed * leftTriggerValue;
        }

        float leftGripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        if (leftGripValue > 0.1f)
        {
            moveDirection += Vector3.down * verticalSpeed * leftGripValue;
        }

        float rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (rightTriggerValue > 0.1f)
        {
            moveDirection += Vector3.up * verticalSpeed * rightTriggerValue;
        }

        float rightGripValue = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        if (rightGripValue > 0.1f)
        {
            moveDirection += Vector3.down * verticalSpeed * rightGripValue;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}