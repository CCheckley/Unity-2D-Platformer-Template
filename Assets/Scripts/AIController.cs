using UnityEngine;

public class AIController : SideScrollingCharacterController
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        Vector2 targetDirection = PlayerController.playerPosition - transform.position;

        character.Move(Mathf.Clamp(targetDirection.x, -1.0f, 1.0f), false);
    }
}