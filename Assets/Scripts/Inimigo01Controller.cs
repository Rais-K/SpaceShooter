using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : InimigoPai
{

    //Pegar o meu RigidBody
    private Rigidbody2D meuRB;
    

    //Pegando o transform da posição do meu tiro
    [SerializeField] private Transform posicaoTiro;

   
    

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        //Dando a velocidade para meu RB
        meuRB.velocity = new Vector2(0f, -velocidade);

        //Deixando a espera aleatória
        esperaTiro = Random.Range(0.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Checar se o meu sprite renderer está visível

        //Pegando informações dos meus "filhos"
        Atirando();
    }

    private void Atirando()
    {
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;



        // Diminuir a minha espera, e se ela for menor ou igual a zero eu atiro

        esperaTiro -= Time.deltaTime;

        if (visivel)
        {
            if (esperaTiro <= 0)
            {

                //Instanciando o meu tiro
                var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeTiro;

                //Reiniciar a nossa espera
                esperaTiro = Random.Range(1.5f, 2f);
            }

        }
    }

}
