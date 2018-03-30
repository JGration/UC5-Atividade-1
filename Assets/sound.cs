using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    public static AudioClip Laser1, Run, Jump;
    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        Laser1 = Resources.Load<AudioClip>("Laser1");
        Run = Resources.Load<AudioClip>("Run");
        Jump = Resources.Load<AudioClip>("Jump");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Play(string clip)
    {
        switch (clip)
        {
            case "Laser1":
                audioSrc.PlayOneShot(Laser1);
                break;
            case "Run":
                audioSrc.PlayOneShot(Run);
                break;
            case "Jump":
                audioSrc.PlayOneShot(Jump);
                break;
        }
    }
}
