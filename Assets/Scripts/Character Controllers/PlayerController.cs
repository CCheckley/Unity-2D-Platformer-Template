using UnityEngine;

public class PlayerController : ICharacterController
{
    public void HandleInput(Character2D character)
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        bool isJumping = Input.GetButtonDown("Jump");

        character.Move(xInput, isJumping);
    }
}
