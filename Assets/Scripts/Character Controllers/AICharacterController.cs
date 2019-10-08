using UnityEngine;

public class AICharacterController : CharacterController2D
{
    public override CharacterCommand HandleInput()
    {
        //This is randomly selecting direction, change this to change how AI Characters work
        float xInput = Random.Range(-1.0f, 1.0f);
        bool isJumping = Random.Range(-1.0f, 1.0f) > 0;

        if (xInput != 0 || isJumping)
            return new CharacterMoveCommand(xInput, isJumping);

        return null;
    }
}
