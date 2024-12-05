using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    const int speed = 5;
    [SerializeField] int score;
    new Rigidbody2D rigidbody2D;

    public int Score { get => score; }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2D.velocity = Vector2.up * -speed;

        if(transform.position.y < -GameManager.instance.ScreenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}

public class Maçã : Apple
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerDelegate.AppleCollected();
            Destroy(gameObject);
        }
    }
}