using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Paddle : MonoBehaviour
{
    public AudioClip hitSound;

    public AudioSource speaker;

    public void MadeContact()
    {
        speaker.PlayOneShot(hitSound);
    }   
}
