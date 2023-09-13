using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private float radius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Movement();
        }

    }

    private void Movement()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);

        if (isGrounded)
        {
            rb.AddForce(Vector2.up * upForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
