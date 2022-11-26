using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D tiroRB;
    
    [SerializeField] private GameObject impacto;
    

    // Start is called before the first frame update
    void Start()
    {
        tiroRB = GetComponent<Rigidbody2D>();

       // tiroRB.velocity = new Vector2(0f, velTiro); 

    }

    // Update is called once per frame
    void Update()
    {
      



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pegar o método PerdeVida e aplicar nele o dano (other)
        //Só deve rodar se ele colidiu com quem tem o script inimigo 01 controller
        //Chaecando se a tag de quem estou colidindo é "inimigo01"
        if (collision.CompareTag("Inimigo"))
        {
            collision.GetComponent<InimigoPai>().PerdeVida(1);
        }

       /* if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<PlayerController>().PerdeVida(1);
        }
       */
        Destroy(gameObject);

        if (collision)
        {
            Instantiate(impacto, transform.position, transform.rotation);

        }

    }
}
