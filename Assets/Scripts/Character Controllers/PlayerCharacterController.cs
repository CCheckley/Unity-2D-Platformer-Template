using UnityEngine;

public class PlayerCharacterController : CharacterController2D
{
    public override CharacterCommand HandleInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        bool isJumping = Input.GetButtonDown("Jump");

        if (xInput != 0 || isJumping)
            return new CharacterMoveCommand(xInput, isJumping);

        return null;
    }
}
