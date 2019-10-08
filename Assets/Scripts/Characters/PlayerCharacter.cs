public class PlayerCharacter : Character2D
{
    protected override void Start()
    {
        base.Start();
        characterController = new PlayerCharacterController();
    }

    protected override void Update()
    {
        base.Update();
    }
}
