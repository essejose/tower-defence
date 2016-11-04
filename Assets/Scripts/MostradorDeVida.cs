using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostradorDeVida : MonoBehaviour {

    private Text campoTexto;
    [SerializeField]
    private Jogador jogador;
	// Use this for initialization
	void Start () {

       campoTexto = GetComponent<Text>();
	}

    void Update()
    {
        campoTexto.text = "Vida :" + jogador.GetVida() ;
    }
	
	
}
