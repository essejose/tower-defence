using UnityEngine;
using System.Collections;

public class DetectorDeCruzamento : MonoBehaviour {


    [SerializeField]
    private Jogador jogador;


	 void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Inimigo")
        {
            Debug.Log("Chegou");
            Destroy(collider.gameObject);
            jogador.PerdeVida();
        }
    }
}
