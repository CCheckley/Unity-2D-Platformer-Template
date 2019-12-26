using UnityEngine;

public class PlayerController : SideScrollingCharacterController
{
    public static Vector3 playerPosition;

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        character.Move(Input.GetAxisRaw("Horizontal"), Input.GetButtonDown("Jump"));

        playerPosition = transform.position;
    }
}
