using UnityEngine;
using System.Collections;

public class torre : MonoBehaviour {

    public GameObject projeilPrefab;
    public float tempoDeRecarga = 1f;
    private float momentoDoUltimoDisparo;
    [SerializeField]
    private float raioDeAlcance;
 

    // Use this for initialization
	void Update () {

        Inimigo alvo = EscolheAlvo();
        if(alvo != null)
        {
            Atira(alvo);

        }
    }
	
	 public void Atira(Inimigo inimigo)
    {
        float tempoAtual = Time.time;

        if(tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga)
        {
            momentoDoUltimoDisparo = tempoAtual;
            GameObject pontoDeDisparo = this.transform.Find("CanhaoDaTorre/PontoDeDisparo").gameObject;
         
            Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
            GameObject projetilObject =
                (GameObject) Instantiate(projeilPrefab,posicaoDoPontoDeDisparo,Quaternion.identity);
            missil missil = projetilObject.GetComponent<missil>();
            missil.DefineAlvo(inimigo); 
        }
    }

    private Inimigo EscolheAlvo()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        foreach (GameObject inimigo in inimigos)
        {
            if (EstaNoRaioDeAlcance(inimigo))
            {
                return inimigo.GetComponent<Inimigo>();
            }
        }

        return null;
    }
    private bool EstaNoRaioDeAlcance(GameObject inimigo)
    {
        Vector3 posicaoDaTorre = this.transform.position;

        Vector3 posicaoNoPlano = Vector3.ProjectOnPlane(posicaoDaTorre,Vector3.up);


        Vector3 posicaoDoInimigo = inimigo.transform.position;


        Vector3 posicaoNoInimigoPlano = Vector3.ProjectOnPlane(posicaoDoInimigo, Vector3.up);

        float distanciaParaInimigo = Vector3.Distance(posicaoDaTorre, posicaoNoInimigoPlano);



        return distanciaParaInimigo <= raioDeAlcance;
    }
}
