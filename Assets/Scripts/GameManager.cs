using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("Game Manager is null");

                return _instance;
            } else {
                return null;
            }
        }
    }
	public Ball ball;
    private int CPU_Score;
    private int Player_Score;
	public Dictionary<string, float> difficultySpeeds =  new Dictionary<string, float>(){
        {"Easy", 5f},
        {"Medium", 10f},
        {"Hard", 15f} 
    }; 
    public enum Difficulty{ Easy, Medium, Hard }
    public Difficulty difficulty;
	private Difficulty saveDifficulty;
	public Dictionary<string, float> difficultyPos =  new Dictionary<string, float>(){
        {"Easy", 12.75f},
        {"Medium", 14.45f},
        {"Hard", 16.15f} 
    };
	public GameObject currentDifficulty;
    
    private void Awake() {
        _instance = this;
    }

	private void Update() {
		saveDifficulty = difficulty;
		if (Input.GetKey(KeyCode.E) && saveDifficulty != Difficulty.Easy) {
            difficulty = Difficulty.Easy;
        } else if (Input.GetKey(KeyCode.M) && saveDifficulty != Difficulty.Medium) {
            difficulty = Difficulty.Medium;
        } else if (Input.GetKey(KeyCode.H) && saveDifficulty != Difficulty.Hard) {
            difficulty = Difficulty.Hard;
        }

		if (saveDifficulty != difficulty) {
			ResetGame();
		}
	}

	public void ResetBall() {
		ball.ResetBall();
	}

	private void ResetGame() {
		CPU_Score = 0;
		Player_Score = 0;
		ball.ResetBall();
		LeanTween.moveX(currentDifficulty, difficultyPos[difficulty.ToString()], 0.5f);
	}

    public void SetScore(string side) {
        switch(side) {
            case "Player":
                CPU_Score++;
                break;
            case "CPU":
                Player_Score++;
                break;
        }
    }

    public int GetScore(string side) {
        switch(side) {
            case "Player":
                return Player_Score;
            case "CPU":
                return CPU_Score;
            default:
                return 0;
        }
    }
}
