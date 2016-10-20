using UnityEngine;
using System.Collections;

public class missil : MonoBehaviour {

    private float velocidade = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Anda();
	}

    private void Anda()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
        transform.position = posicaoAtual + deslocamento;
    }
}
