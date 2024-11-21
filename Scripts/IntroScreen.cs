using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreen : MonoBehaviour
{
    public GameObject introBackground;
    public GameObject introText;

    void Start(){
        StartCoroutine(Intro());
    }
    IEnumerator Intro(){
        yield return new WaitForSeconds(3);
        //turns off the black inro screen and welcome text
        introBackground.SetActive(false);
        introText.SetActive(false);
    }
}
