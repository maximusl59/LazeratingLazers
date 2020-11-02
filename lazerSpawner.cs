using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerSpawner : MonoBehaviour
{
    private static float xMin = -2.815f;
    private static float xMax = 2.815f;
    private static float yMin = -5f;
    private static float yMax = 5f;
    private static float deltaDelay = 0.1f;

    static bool firstTime = true;

    public GameObject lazer;
    public float startDelay;
    public float endDelay;
    float currentDelay;
    float timeOfDelay;
    float delayDelay;

    float xPos;
    float yPos;

    void Awake() {
        currentDelay = startDelay;
        if (firstTime) {
            delayDelay = 1f;
            timeOfDelay = 1f;
        }
    }

    void Update() {
        if (currentDelay > endDelay && Time.timeSinceLevelLoad > delayDelay) {
            delayDelay += 5;
            currentDelay -= deltaDelay;
        }

        if (Time.timeSinceLevelLoad > timeOfDelay) {
            updateTOD();
            Instantiate(lazer, RandomPos(), Quaternion.identity);
        }
        
        if (Time.timeScale == 0) {
            firstTime = false;
        }
    }

    Vector3 RandomPos() {
        int result = Random.Range(1, 5);
        switch (result) {
            case 1:
                xPos = xMin;
                yPos = Random.Range(yMin, yMax);
                break;
            case 2:
                xPos = xMax;
                yPos = Random.Range(yMin, yMax);
                break;
            case 3:
                xPos = Random.Range(xMin, xMax);
                yPos = yMin;
                break;
            case 4:
                xPos = Random.Range(xMin, xMax);
                yPos = yMax;
                break;
        }

        return new Vector3(xPos, yPos, 1f);
    }

    void updateTOD() {
        timeOfDelay += currentDelay;
    }

}
