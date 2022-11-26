using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject meuTiro;
    [SerializeField] private Transform posicaoTiro;
    [SerializeField] private int vida = 5;
    [SerializeField] private GameObject explosao;
    [SerializeField] private float velocidadeTiro = 8f;


    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();

        Atirando();

    }

    private void Movendo()
    {
        //Pegando o input horizontal

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);

        //Normalizando a velocidade na diagonal
        minhaVelocidade.Normalize();



        //Passando a minha velicdade para meu RB
        meuRB.velocity = minhaVelocidade * velocidade;
    }

    private void Atirando()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
            //Dar a direção e velocidade para o RB do tiro
            tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);

        }
    }

    public void PerdeVida(int dano)
    {
        //Perdendo a minha vida com base no dano
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosao, posicaoTiro.position, transform.rotation);
        }
    }

    
}
