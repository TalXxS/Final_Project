using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Awake()
    {
        // Get components, same game objects components are called in awake.
        if (rb  ==  null) rb = GetComponent<Rigidbody2D>();
        if  (animator == null) animator = GetComponent<Animator>();
            
    }

    void Update()
    {
        // Get input from the keyboard (e.g., A/D or Left/Right arrows)
        // Input.GetAxisRaw provides sharp stop/start, useful for precise movement
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical"); // For top-down movement
        
        // Player Flip
        if (movementInput.x > 0) transform.localScale = new Vector2(1, 1);
        if (movementInput.x < 0) transform.localScale = new Vector2(-1, 1);
            
    }

    void FixedUpdate()
    {
        // Physics updates should be done in FixedUpdate
        if (rb != null)
        {
            // Calculate the target position
                // Use Vector2 everywhere to avoid mixing Vector2 and Vector3 types
            Vector2 targetPosition = rb.position + movementInput * moveSpeed * Time.fixedDeltaTime;

            // Move the Rigidbody to the target position
            // This method handles collisions with dynamic colliders
            rb.MovePosition(targetPosition);
        }
    }
}
