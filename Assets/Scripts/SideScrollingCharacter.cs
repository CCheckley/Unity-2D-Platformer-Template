using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class SideScrollingCharacter : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    [SerializeField] float movementSpeed = 1000.0f;
    [SerializeField] float jumpForce = 5000.0f;
    [SerializeField] LayerMask floorLayer;

    bool isFacingRight;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.mass = 1.0f;
        rigidbody2D.isKinematic = false;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 10.0f;

        isFacingRight = (transform.localScale.x > 0);
    }

    public void Move(float xInput, bool isJumping)
    {
        float xDelta = (xInput * movementSpeed) * Time.deltaTime;
        float yDelta = (isJumping && HasLanded()) ? jumpForce * Time.deltaTime : rigidbody2D.velocity.y;

        rigidbody2D.velocity = new Vector2(xDelta, yDelta);

        if ((xDelta > 0 && !isFacingRight) || (xDelta < 0 && isFacingRight))
            FlipHorizontal();
    }

    public void FlipHorizontal()
    {
        Vector3 targetScale = transform.localScale;
        targetScale.x = -transform.localScale.x;
        transform.localScale = targetScale;

        isFacingRight = !isFacingRight;
    }

    public bool HasLanded()
    {
        return rigidbody2D.IsTouchingLayers(floorLayer);
    }
}
