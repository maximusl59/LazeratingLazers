using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiScript : MonoBehaviour
{
    public void retry() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void quit() {
        Application.Quit();
    }

    public void startGame() {
        Animator anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        anim.SetTrigger("transition");
        SceneManager.LoadScene(1);
       //StartCoroutine("wait");
    }

    /*
    IEnumerator wait() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    */
}
