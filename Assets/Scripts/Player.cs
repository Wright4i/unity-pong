using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, -9f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3((moveSpeed * -1) * Time.deltaTime, 0f, 0f);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
