using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetTrigger("Sit");
    }
}
