using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour
{

    [SerializeField]
    private float vida;


    // Use this for initialization
    void Start()
    {
        UnityEngine.AI.NavMeshAgent agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject fimdocaminho = GameObject.Find("FimDoCaminho");
        Vector3 posicaoDofimCaminho = fimdocaminho.transform.position;
        agente.SetDestination(posicaoDofimCaminho);

    }

    public void RecebeDano(int pontosDeDano)
    {
        vida -= pontosDeDano;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
