using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Vector3 startPos = new Vector3(15f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -7.75f) {
            transform.position += new Vector3(0f, (moveSpeed * -1) * Time.deltaTime, 0f);
        } else if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 7.75f) {
            transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        }
    }
}
