using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    private Transform personagem;                 // CAMPO ONDE SERA O INDICADO O PERSONAGEM QUE VAI FOCAR A CAMERA             
    public  float     velocidade=0.5f;           //   VELOCIDADE DA CAMERA
    
                                      
    void Start()
    {
        // AQUI E FEITA A BUSCA DA CAMERA PELA TAG NINJA QUE ESTA ASSOCIADA AO PERSONAGEM
           personagem = GameObject.FindGameObjectWithTag("Player").transform; 

    }

    void Update ()
    {

        // METODO USADO PARA  FAZER A CAMERA SEGUIR O PERSONAGEM
        transform.position = Vector3.Lerp(transform.position, new Vector3(personagem.position.x, personagem.position.y, transform.position.z), velocidade);

    }
}
