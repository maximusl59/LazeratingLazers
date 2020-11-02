using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerController : MonoBehaviour
{
    private static float xMin = -2.815f;
    private static float xMax = 2.815f;
    private static float yMin = -5f;
    private static float yMax = 5f;

    GameObject player;
    camShake cS;
    public float upTime;
    float currentTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cS = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShake>();
        updateRotation();
    }

    void Update()
    {
        if (currentTime > upTime)
            Destroy(this.gameObject);

        currentTime += Time.deltaTime;
    }

    void updateRotation() {
        if (Random.Range(1, 3) == 1) {
            if (this.gameObject.transform.position.x > 0 && this.gameObject.transform.position.y > 0) {
                int result = Random.Range(1, 5);
                switch (result) {
                    case 1:
                        performRotation(new Vector3(xMin, randomizer("yDown"), 1));
                        break;
                    default:
                        performRotation(new Vector3(randomizer("xDown"), yMin, 1));
                        break;
                }
            }
            else if (this.gameObject.transform.position.x > 0 && this.gameObject.transform.position.y < 0) {
                int result = Random.Range(1, 5);
                switch (result) {
                    case 1:
                        performRotation(new Vector3(xMin, randomizer("yUp"), 1));
                        break;
                    default:
                        performRotation(new Vector3(randomizer("xDown"), yMax, 1));
                        break;
                }
            }
            else if (this.gameObject.transform.position.x < 0 && this.gameObject.transform.position.y > 0) {
                int result = Random.Range(1, 5);
                switch (result) {
                    case 1:
                        performRotation(new Vector3(xMax, randomizer("yDown"), 1));
                        break;
                    default:
                        performRotation(new Vector3(randomizer("xUp"), yMin, 1));
                        break;
                }
            }
            else if (this.gameObject.transform.position.x < 0 && this.gameObject.transform.position.y < 0) {
                int result = Random.Range(1, 5);
                switch (result) {
                    case 1:
                        performRotation(new Vector3(xMax, randomizer("yUp"), 1));
                        break;
                    default:
                        performRotation(new Vector3(randomizer("xUp"), yMax, 1));
                        break;
                }
            }
        } else {
            performRotation(player.transform.position);
        }
    }

    float randomizer(string coord) {
        if (coord == "xUp") {
            return Random.Range(0, xMax);
        } else if (coord == "xDown") {
            return Random.Range(xMin, 0);
        } else if (coord == "yUp") {
            return Random.Range(0, yMax);
        } else if (coord == "yDown") {
            return Random.Range(yMin, 0);
        }

        return 0;
    }

    void performRotation(Vector3 dir) {
        var facing = dir - this.transform.position;
        var angle = Mathf.Atan2(facing.y, facing.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void shake() {
        cS.doShake();
    }
}
