using UnityEngine;

public class MoveWithHeadRotation : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private CharacterController characterController;
    private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }

        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (characterController != null && cameraTransform != null)
        {
            Vector3 moveDirection = cameraTransform.forward * moveSpeed * Time.deltaTime;

            characterController.Move(moveDirection);
        }
    }
}
