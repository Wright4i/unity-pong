using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOB : MonoBehaviour
{
    private OOB current;
    private GameManager GM;

    void Start() {
        current = this;
        GM = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        GM.SetScore(current.tag);
        GM.ResetBall();
    }
}
