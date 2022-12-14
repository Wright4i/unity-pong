using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameManager GM;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GM = FindObjectOfType<GameManager>();

        ResetBall();
    }

    public void ResetBall() {
        rb2d.position = new Vector3(0f, 0f, 0f);
        rb2d.velocity = new Vector2(0f, 0f);

        Invoke("ServeBall", 2);
    }

    public void ServeBall() {

        float forceX = GM.difficultySpeeds[GM.difficulty.ToString()];
        float forceY = GM.difficultySpeeds[GM.difficulty.ToString()] / 2f;
        float rand = Random.Range(0f, 2f);

        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(forceX, forceY));
        }
        else
        {
            rb2d.AddForce(new Vector2(forceX * -1, forceY));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 vel;

            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

}