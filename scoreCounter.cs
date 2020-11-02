using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreCounter : MonoBehaviour
{
    static bool firstTime = true;

    public bool isAlive;
    public int Speed;
    float Score;
    int highestScore;
    bool canPlay = true;
    TextMeshProUGUI tmp;
    Animator anim;
    public TextMeshProUGUI best;
    Animator bestAnim;
 
    void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        anim = this.GetComponent<Animator>();
        bestAnim = best.GetComponent<Animator>();
        loadHighScore();
    }

    void Update()
    {
        if ((Mathf.Round(Score) == 100 || Mathf.Round(Score) == 1000 || Mathf.Round(Score) == 10000) && canPlay) {
            canPlay = false;
            anim.SetTrigger("grow");
            Invoke("enableCanPlay", 3f);
        }

        if (isAlive && (Time.timeSinceLevelLoad > 1f || !firstTime)) {
            Score += Time.deltaTime * Speed;
            tmp.text = Mathf.Round(Score).ToString();
        }
        
        if (Time.timeScale == 0) {
            if (Score > highestScore) {
                highestScore = (int)Mathf.Round(Score);
                saveHighScore();
            }
            endGame();
        }
    }
    
    void endGame() {
        firstTime = false;
        best.text = "Best: " + highestScore;
        anim.SetTrigger("end");
        bestAnim.SetTrigger("end");
    }

    void enableCanPlay() {
        canPlay = true;
    }

    public int getHighestScore() {
        return highestScore;
    }

    void saveHighScore() {
        saveSystem.saveGame(this);
    }

    void loadHighScore() {
        highScore hS = saveSystem.loadGame();

        highestScore = hS.hiScore;
    }

}
