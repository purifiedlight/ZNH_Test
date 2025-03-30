using UnityEngine;

public class TeleportOnButtonPress : MonoBehaviour
{
    public Vector3 positionA = new Vector3(235, 6, 650);
    public Vector3 positionB = new Vector3(-873, -38, 442);

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            TeleportToPosition(positionA);
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            TeleportToPosition(positionB);
        }
    }

    void TeleportToPosition(Vector3 targetPosition)
    {
        if (characterController != null)
        {
            characterController.enabled = false;
            characterController.transform.position = targetPosition;
            characterController.enabled = true;
        }
    }
}
