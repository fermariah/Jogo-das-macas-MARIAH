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

public class Ma�� : Apple //classe derivada de apple para implementar o delegate do gamemanager e destruir o objeto
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerDELEGATE.MacaColetada();
            Destroy(gameObject);
        }
    }
}
