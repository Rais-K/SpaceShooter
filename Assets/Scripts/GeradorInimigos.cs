using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;

    private int pontos = 0;
    [SerializeField] private int level = 1;

    private float esperaInimigo = 0f;
    [SerializeField] float tempoEspera = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();
    }

    //Criando um timer para o surgimento dos inimigos
    private void GeraInimigos()
    {
        esperaInimigo -= Time.deltaTime;

        //Checando se a espera ja zerou
        if (esperaInimigo < 0f)
        {
            int quantidade = level * 4;
            int qtdInimigo = 0;
            //Criando varios inimigos de uma só vez
            while (qtdInimigo > quantidade)
            {


                GameObject inimigoCriado;


                //Decidindo qual inimigo vai ser criado com base no level
                float chance = Random.Range(0f, level);
                if (chance > 2f)
                {
                    inimigoCriado = inimigos[1];
                }
                else
                {
                    inimigoCriado = inimigos[0];
                }

                //definindo a posição do inimigo
                Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 16f), 0f);

                //criando um inimigo
                Instantiate(inimigoCriado, posicao, transform.rotation);

                //aumentando a quantidade de inimigos
                qtdInimigo++;

                //reiniciando a espera
                esperaInimigo = tempoEspera;
            }
        }
    }
}
