public class AICharacter : Character2D
{
    protected override void Start()
    {
        base.Start();
        characterController = new AIController();
    }

    protected override void Update()
    {
        base.Update();
    }
}
