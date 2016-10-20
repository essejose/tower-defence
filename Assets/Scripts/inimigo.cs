using UnityEngine;
using System.Collections;

public class inimigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        GameObject fimdocaminho = GameObject.Find("FimDoCaminho");
        Vector3 posicaoDofimCaminho = fimdocaminho.transform.position;
        agente.SetDestination(posicaoDofimCaminho);

	}
 
}
