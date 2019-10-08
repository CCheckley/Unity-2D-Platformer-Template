public class AICharacter : Character2D
{
    protected override void Start()
    {
        base.Start();
        characterController = new AICharacterController();
    }

    protected override void Update()
    {
        base.Update();
    }
}
