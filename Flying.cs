using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float speed = 4; //velocidade do flying

    void Start()
    {
        
    }

 
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; //movimenta para a esquerda
        if(transform.position.x <= -5)
        {
            Destroy(gameObject); //destruirá este objeto se sua posição for menor ou igual a -5
        }
    }
}
