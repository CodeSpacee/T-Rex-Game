using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float speed = 3; //velocidade das nuvens

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; //movimentará o objeto para a esquerda
        if(transform.position.x <= -5)
        {
            Destroy(gameObject);
        } 
        //Se a posição em relação ao eixo X for menor ou igual a -5 destruirá este objeto.
    }
}
