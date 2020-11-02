using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePuck : MonoBehaviour
{
    public scoreCounter sC;

    public float power;
    public float minPower;
    public float maxPower;

    Rigidbody2D rb2d;

    public Camera cam;
    Vector2 force;
    Vector3 startPt;
    Vector3 endPt;

    public GameObject UI;

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            startPt = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            startPt.z = 15;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            endPt = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            endPt.z = 15;

            force = new Vector2(Mathf.Clamp(endPt.x - startPt.x, minPower, maxPower), Mathf.Clamp(endPt.y - startPt.y, minPower, maxPower));
            rb2d.AddForce(force * power, ForceMode2D.Force);
        }
        */ //this is for mobile controls

        if (Input.GetMouseButtonDown(0)) {
            startPt = cam.ScreenToWorldPoint(Input.mousePosition);
            startPt.z = 15;
        }

        if (Input.GetMouseButtonUp(0)) {
            endPt = cam.ScreenToWorldPoint(Input.mousePosition);
            endPt.z = 15;

            force = new Vector2(Mathf.Clamp(endPt.x - startPt.x, minPower, maxPower), Mathf.Clamp(endPt.y - startPt.y, minPower, maxPower));
            rb2d.AddForce(force * power, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        endGame();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "UDBorder") {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
        }
        else if (collision.gameObject.name == "LRBorder") {
            rb2d.velocity = new Vector2(-rb2d.velocity.x, rb2d.velocity.y);
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.name == "UDBorder") {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y * 1.5f);
        }
        else if (collision.gameObject.name == "LRBorder") {
            rb2d.velocity = new Vector2(-rb2d.velocity.x * 1.5f, rb2d.velocity.y);
        }
    }

    void endGame() {
        sC.isAlive = false;
        UI.SetActive(true);
        Time.timeScale = 0f;
        Destroy(this.gameObject);
    }
}
