using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private float groundWidht;

    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        groundWidht = groundCollider.size.x;
    }


    void Update()
    {

        if (transform.position.x < -groundWidht)
        {
            transform.Translate(Vector2.right * 2f * groundWidht);

        }

    }
}