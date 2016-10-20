using UnityEngine;
using System.Collections;

public class torre : MonoBehaviour {

    public GameObject projeilPrefab;
    public float tempoDeRecarga = 1f;
    private float momentoDoUltimoDisparo;
    // Use this for initialization
	void Update () {
        Atira();
    }
	
	 public void Atira()
    {
        float tempoAtual = Time.time;

        if(tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga)
        {
            momentoDoUltimoDisparo = tempoAtual;
        GameObject pontoDeDisparo = this.transform.Find("CanhaoDaTorre/PontoDeDisparo").gameObject;
        Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
        Instantiate(projeilPrefab,posicaoDoPontoDeDisparo,Quaternion.identity);
        }
    }
}
