using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    // Start is called before the first frame update

    private Rigidbody2D meuRB;
    

    [SerializeField] private Transform posicaoTiro;
    [SerializeField] private  float yMax = 2.6f;

    private bool possoMover = true;
 
    


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

        Atirando();

        //Checando se chegeui no meio da tela E se posso me mover
        if (transform.position.y <= yMax && possoMover)
        {
            //Checando de que lado eu estou
            //Checando se estou na direita
            if (transform.position.x > 0f)
            {
                Debug.Log("direita");
                //indo para a esquerda
                meuRB.velocity = new Vector2(-velocidade, -velocidade);

                //falando que não posso mais me mover
                possoMover = false;

            }
            //Checando se estou na esquerda
            if (transform.position.x <= 0f)
            {
                Debug.Log("esquerda");
                //indo para a direita
                meuRB.velocity = new Vector2(+velocidade, -velocidade);

                possoMover = false;
            }


        }


    }

    private void Atirando()
    {
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visivel)
        {
            //Encontrando o player na cena
            var player = FindObjectOfType<PlayerController>();

            //Só fazer qualquer coisa SE o player existir
            if (player)
            {

                esperaTiro -= Time.deltaTime;

                if (esperaTiro <= 0)
                {
                    //Instanciando o meu tiro
                    var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);

                    //Encontrando o valor da direção
                    Vector2 direcao = player.transform.position - tiro.transform.position;

                    //Normalizando a velocidade dele
                    direcao.Normalize();

                    //dando a direção e velocidade do meu tiro
                    tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                    //Dando o angulo que o tiro tem que estar
                    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

                    //Passando o angulo
                    tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                    //Reiniciar a nossa espera
                    esperaTiro = Random.Range(2f, 4f);
                }
            }
        }
    }

}

