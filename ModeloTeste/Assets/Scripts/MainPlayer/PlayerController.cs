using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //VARIAVEIS DOS EIXOS DE MOVIMENTO DO PERSONAGEM
    private float movHorizontal,movVertical;

    //VARIAVEIS DOS MOVIMENTOS DO PERSONAGEM
    private bool parado,
    andando, andandoesq,
    inicio_mov,inicioandandoesq,
    agachando, agachando_esq,
    agachado, agachado_esq,
    pulando, pulando_esq;

    //VARIAVEIS DA FISICA EMPREGADA AO PERSONAGEM
    public Rigidbody2D PlayerRigidbody;
    public Animator animacao;
    public float speed;
    public float jumpForce;
    
    


    void Start()
    {

        // Inicia os valores do pulo para o player
        PlayerRigidbody = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        //Metodo responsavel pela movimentacao
        movimento();

        // Animacoes 
        animacao.SetBool("parado",parado);
        animacao.SetBool("andando",andando);
        animacao.SetBool("inicio_mov",inicio_mov);
        animacao.SetBool("agachando",agachando);
        animacao.SetBool("agachado",agachado);
        animacao.SetBool("pulando",pulando);

    }
     

    public void movimento()
    {
    
        Vector3 move=new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        transform.position += move * Time.deltaTime * speed;
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");


        if (movX == 0 || movY== 0)  //PARADO NA TELA
        {
            parado     = true;
            inicio_mov = false;
            andando    =false;
            pulando    =false;
            agachando  =false;
            agachado   =false;
        
        }
        if (movY < 0)  //PERSONAGEM AGACHANDO
        {
            agachando = true;
           
            if(agachando == true)
            {
                parado     = false;
                inicio_mov = false;
                andando    =false;
                pulando    =false;
                agachado   =true;
            }

        }
        if (movY > 0)  //PERSONAGEM PULANDO
        {  
            PlayerRigidbody.AddForce(new Vector2(0,jumpForce * Time.deltaTime), ForceMode2D.Force);

            pulando = true;
            if(pulando == true)
            {
                pulando    = true;
                parado     = false;
                inicio_mov = false;
                agachando  = false;
                andando    = false;
                agachado   = false;
            } 

        }if (movY > 0 && movX > 0)
        {
                pulando    = true;
                parado      = false;
                inicio_mov  = false;
                agachando   = false;
                andando     = false;
                agachado    = false;


        }if  (movY > 0 && movX < 0)
          {
                pulando     = true;
                parado      = false;
                inicio_mov  = false;
                agachando   = false;
                andando     = false;
                agachado    = false;
          }

        if(movX > 0)  //MOVIMENTACAO PARA DIREITA
        {
            transform.eulerAngles=(new Vector2(0f, 0f));
            inicio_mov = true;

            if(inicio_mov == true) 
            {
        
                parado     =false;
                pulando    =false;
                agachando  =false;
                agachado   =false;
                andando    =false;
              
            }

        }
        if (movX < 0)//MOVIMENTACAO PARA ESQUERDA

        {
            transform.eulerAngles = (new Vector2(0f,180f));
            inicio_mov = true;


            if(inicio_mov == true) 
            {
        
                parado     =false;
                pulando    =false;
                agachando  =false;
                agachado   =false;
                andando    =false;
              
            }
        
        }
  
    
    }


 

}
