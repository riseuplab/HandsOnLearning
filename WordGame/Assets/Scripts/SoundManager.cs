using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    [SerializeField] AudioSource rightAnsSource;
    [SerializeField] AudioSource wrongAnsSource;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public void PlayRightAnsSound()
    {
        rightAnsSource.Play();
    }
    public void PlayWrongAnsSound()
    {
        wrongAnsSource.Play();
    }
}
