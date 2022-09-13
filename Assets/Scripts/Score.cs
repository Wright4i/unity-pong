using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Score current;
    private GameManager GM;
    public Text scoreText;

    void Start() {
        current = this;
        GM = FindObjectOfType<GameManager>();
    }   

    // Update is called once per frame
    void Update()
    {
        scoreText.text = current.tag + "\n" + GM.GetScore(current.tag);
    }
}
