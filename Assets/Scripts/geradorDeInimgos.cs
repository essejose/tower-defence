using UnityEngine;
using System.Collections;

public class geradorDeInimgos : MonoBehaviour {

    [SerializeField]
    private GameObject inimigo;
    [SerializeField]
    private float tempoDeCriacao = 2f;
    private float momentoDaUltimaGeracao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GeraIninimigo();
	}

    private void GeraIninimigo()
    {

        float tempoAtual = Time.time;

        if (tempoAtual > momentoDaUltimaGeracao + tempoDeCriacao)
        {
            momentoDaUltimaGeracao = tempoAtual;
            Vector3 posicaoDoGerador = this.transform.position;
            Instantiate(inimigo, posicaoDoGerador, Quaternion.identity);
        }
    }
}
