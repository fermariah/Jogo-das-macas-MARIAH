using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float speed = 10;
    float direction;
    Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");

        Move();
    }

    private void Move()
    {
        rigidbody2D.velocity = direction * speed * Vector3.right;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(transform.position.x, -GameManager.instance.ScreenBounds.x, GameManager.instance.ScreenBounds.x);
        transform.position = position;
    }
}
