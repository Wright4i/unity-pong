using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3 startPos = new Vector3(-15f, 0f, 0f);
    private enum Direction{ Up, Down }
    private Direction direction;
    private GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        transform.position = startPos;
        moveSpeed = moveSpeed - (GM.difficultySpeeds[GM.difficulty.ToString()] / 10f);
        moveUp();
    }

    private void moveUp() {
        int id = LeanTween.moveY(gameObject, 7.75f, moveSpeed).id;
        LTDescr d = LeanTween.descr(id);

        if(d!=null){
            d.setOnComplete(moveDown);
        }
    }

    private void moveDown() {
        int id = LeanTween.moveY(gameObject, -7.75f, moveSpeed).id;
        LTDescr d = LeanTween.descr(id);

        if(d!=null){ 
            d.setOnComplete(moveUp);
        }
    }
}