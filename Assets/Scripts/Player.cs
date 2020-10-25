using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public CharacterController characterController;
    public CapsuleCollider capsuleCollider;
    private float moveSpeed = 8f;
    
    void Start()
    {
        capsuleCollider.enabled = true;
    }

    public override void OnStartLocalPlayer()
    {
        characterController.enabled = true;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = Vector3.ClampMagnitude(direction, 1f);
        direction = transform.TransformDirection(direction);
        direction *= moveSpeed;

        characterController.SimpleMove(direction);
    }
}
