using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Character2D : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Animator animator;
    CircleCollider2D circleCollider;

    protected CharacterController2D characterController;

    [SerializeField] protected LayerMask floorLayer;
    [SerializeField] protected float movementSpeed = 1000.0f;
    [SerializeField] float jumpForce = 5000.0f;

    private bool isFacingRight;

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();

        //Setup character rigidbody
        rigidbody2D.isKinematic = false;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 10.0f;

        isFacingRight = (transform.localScale.x > 0);
    }

    protected virtual void Update()
    {
        CharacterCommand characterCommand = characterController.HandleInput();
        if (characterCommand != null)
            characterCommand.Execute(this);
    }

    public void Move(float xInput, bool isJumping)
    {
        float xDelta = (xInput * movementSpeed) * Time.deltaTime;
        float yDelta = (isJumping && HasLanded()) ? jumpForce * Time.deltaTime : rigidbody2D.velocity.y;

        rigidbody2D.velocity = new Vector2(xDelta, yDelta);

        if ((xDelta > 0 && !isFacingRight) || (xDelta < 0 && isFacingRight))
            FlipHorizontal();
    }

    private void FlipHorizontal()
    {
        Vector3 targetScale = transform.localScale;
        targetScale.x = -transform.localScale.x;
        transform.localScale = targetScale;

        isFacingRight = !isFacingRight;
    }

    bool HasLanded()
    {
        return rigidbody2D.IsTouchingLayers(floorLayer);
    }
}
