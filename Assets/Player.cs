using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    Vector3 originalScale;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalValue = Input.GetAxisRaw("Vertical");
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        if (horizontalValue != 0 || verticalValue != 0)
        {

            Vector3 deltaX = Vector3.right * (speed * horizontalValue * Time.deltaTime);
            Vector3 deltaY = Vector3.up * (speed * verticalValue * Time.deltaTime);
            Vector3 target = transform.position + deltaX + deltaY;

            // check if the next position is inside the walkable area



            float sign = 1;
            if (horizontalValue < 0)
                sign = -1;

            transform.localScale = new Vector3(
                sign * originalScale.x,
                originalScale.y,
                originalScale.z);
        }
    }
}
