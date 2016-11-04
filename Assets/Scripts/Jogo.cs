using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour
{

    [SerializeField]
    private GameObject torrePrefab;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private Jogador jogador;


    void Start()
    {
        gameOver.SetActive(false);
    }
    private bool ClicouComBotaoPrimario()
    {
        return Input.GetMouseButtonDown(0);
    }
    void Update()
    {

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

    public void RecomecaJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ControiTorre()
    {
        Vector3 posicaoDoClique = Input.mousePosition;
        RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto(posicaoDoClique);

        Debug.Log(elementoAtingidoPeloRaio);
        if (elementoAtingidoPeloRaio.collider != null)
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

        Physics.Raycast(raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);

        return elementoAtingidoPeloRaio;
    }
}
