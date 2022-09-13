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
    
    private void Awake() {
        _instance = this;
    }

	public void ResetBall() {
		ball.ResetBall();
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
