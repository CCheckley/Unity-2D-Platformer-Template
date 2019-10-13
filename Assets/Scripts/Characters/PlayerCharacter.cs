public class PlayerCharacter : Character2D
{
    protected override void Start()
    {
        base.Start();
        characterController = new PlayerController();
    }

    protected override void Update()
    {
        base.Update();
    }
}
