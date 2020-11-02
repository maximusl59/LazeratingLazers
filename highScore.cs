using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class highScore {
    public int hiScore;

    public highScore(scoreCounter sC) {
        hiScore = sC.getHighestScore();
    }
}
