using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {
    [SerializeField]
    private int score = 0;

    public void SetScore(int newScore) {
        score = newScore;
    }

    public int GetScore() {
        return score;
    }
}
