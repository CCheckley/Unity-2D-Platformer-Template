public class CharacterMoveCommand : CharacterCommand
{
    private float xInput;
    private bool isJumping;

    public CharacterMoveCommand(float _xInput, bool _isJumping)
    {
        xInput = _xInput;
        isJumping = _isJumping;
    }

    public override void Execute(Character2D character)
    {
        character.Move(xInput, isJumping);
    }
}
