using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(-15, 20));
        }
        else
        {
            rb2d.AddForce(new Vector2(-15, -20));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Boing");

        if (collision.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = (rb2d.velocity.x / 2) + (collision.collider.attachedRigidbody.velocity.x / 3);
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
        }
    }

}