using UnityEngine;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Dictionary<string, float> difficultySpeeds =  new Dictionary<string, float>(){
        {"Easy", 5},
        {"Medium", 10},
        {"Hard", 15} 
    }; 
    public enum Difficulty{ Easy, Medium, Hard }
    public Difficulty difficulty;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("ServeBall", 2);
    }

    void ServeBall()
    {
        float forceX = difficultySpeeds[difficulty.ToString()];
        float forceY = difficultySpeeds[difficulty.ToString()] / 2;
        float rand = Random.Range(0, 2);
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
            Debug.Log(rb2d.velocity.x);
            
            Debug.Log(rb2d.velocity.y);
            Debug.Log(collision.collider.attachedRigidbody.velocity.y);

            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

}