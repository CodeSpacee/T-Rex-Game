using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{

    public float speed = 3; //velocidade do movimento do cacto

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; //movimento do cacto para a esquerda
        if(transform.position.x <= -5)
        {
            Destroy(gameObject);
        }

        //O script acima faz com que se o cacto siar do campo d evisão da câmera ele seja destruido.
    }
}
