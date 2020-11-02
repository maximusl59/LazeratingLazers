using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camShake : MonoBehaviour
{
    public static bool firstTime = true;
    public Animator anim;

    void Update() {
        anim.SetBool("FirstTime?", firstTime);
        firstTime = false;
    }

    public void doShake() {
        anim.SetTrigger("shake");
    }
}
