using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joker : MonoBehaviour
{
    public static bool jokerOn = false;
    public AudioSource laugh;

    public GameObject joker;
    public void JokerOn()
    {
        jokerOn = true;
        joker.SetActive(false);
        laugh.Play();

    }
}
