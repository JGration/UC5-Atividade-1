using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vencedor : MonoBehaviour {

    private MensagemControle MC;
	// Use this for initialization
	void Start () {
        GameObject mensagemControleObject = GameObject.FindWithTag("MensagemControle");
        if(mensagemControleObject != null)
        {
            MC = mensagemControleObject.GetComponent<MensagemControle>();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MC.Venceu();
        }
        Destroy(other.gameObject);
    }
}
