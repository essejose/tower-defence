using UnityEngine;
using System.Collections;

public class Jogo : MonoBehaviour {

    [SerializeField]
    private GameObject torrePrefab;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private Jogador jogador;


    void Start() {
        gameOver.SetActive(false);
    }
    private bool ClicouComBotaoPrimario ()
    {
        
        return Input.GetMouseButtonDown(0);
    }
	// Update is called once per frame
	void Update () {

        Debug.Log(jogoAcabou());
        if (jogoAcabou())
        {
            gameOver.SetActive(true);
        }

        if (ClicouComBotaoPrimario())
        {
            ControiTorre();
        }

	}
    private bool jogoAcabou()
    {
        return !jogador.Estavivo();
    }

    void ControiTorre()
    {
        Vector3 posicaoDoClique = Input.mousePosition;
        RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto(posicaoDoClique);

        Debug.Log(elementoAtingidoPeloRaio);
        if(elementoAtingidoPeloRaio.collider != null)
        {
            Vector3 posicaoDeCriacaoDaTorre = elementoAtingidoPeloRaio.point;
            Instantiate(torrePrefab, posicaoDeCriacaoDaTorre, Quaternion.identity);
        }
    }

    private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 pontoInicial)
    {
        Ray raio = Camera.main.ScreenPointToRay(pontoInicial);
        RaycastHit elementoAtingidoPeloRaio;
        float comprimentoMaximoDoRaio = 100.0f;

        Physics.Raycast(raio, out elementoAtingidoPeloRaio,comprimentoMaximoDoRaio);

        return elementoAtingidoPeloRaio;
    }
}
