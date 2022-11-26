using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{

    // Start is called before the first frame update

    //Atributos que todos os inimigos devem ter
    [SerializeField] protected float velocidade;
    [SerializeField] protected int vida;
    [SerializeField] protected GameObject explosao;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected GameObject meuTiro;
    [SerializeField] protected float velocidadeTiro = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Criando o m�todo perde vida
    public void PerdeVida(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);
        }
    }

    //Se destruindo ao colidir com o destruidor
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checando se o outro cara � o destruidor
        if (other.CompareTag("Destruidor"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);

            //Tirando vida do player
            other.gameObject.GetComponent<PlayerController>().PerdeVida(1);
        }
    }
    
        
}




