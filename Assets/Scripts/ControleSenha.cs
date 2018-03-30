﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSenha : MonoBehaviour {

    public GameObject porta;
    public GameObject sinal;
    public GameObject portaFechada;

    private bool Aberto = false;

    private Mudacor pc1;
    private Mudacor pc2;
    private Mudacor pc3;

    private AudioSource aSource;

    void Start () {
        GameObject pedraCorObject = GameObject.FindWithTag("Pedra1");
        if (pedraCorObject != null)
        {
            pc1 = pedraCorObject.GetComponent<Mudacor>();
        }

        pedraCorObject = GameObject.FindWithTag("Pedra2");
        if (pedraCorObject != null)
        {
            pc2 = pedraCorObject.GetComponent<Mudacor>();
        }

        pedraCorObject = GameObject.FindWithTag("Pedra3");
        if (pedraCorObject != null)
        {
            pc3 = pedraCorObject.GetComponent<Mudacor>();
        }

        aSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(pc1.valPedra == 1 && pc2.valPedra == 1 && pc3.valPedra == 1 && !Aberto)
        {
            Vector3 spawnPos = new Vector3(7.32f, -3.41f, -0.5f);
            Quaternion spawnRot = Quaternion.identity;
            Instantiate(porta, spawnPos, spawnRot);

            if(aSource.isPlaying)
            {
                aSource.Stop();
            }

            spawnPos = new Vector3(6f, -4f, -0.5f);
            spawnRot = Quaternion.identity;
            Instantiate(sinal, spawnPos, spawnRot);

            Aberto = true;

            if (portaFechada != null)
                portaFechada.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pc1.valPedra == 1 && pc2.valPedra == 1 && pc3.valPedra == 1 && !Aberto)
        {
            aSource.Play();
        }
    }
}
