using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    Vector2 yVelocity; //velocidade com relação ao eixo Y

    float maxHeight = 1f; //altura maxima
    float timeToPeak = 0.3f; //tempo do pulo

    float jumpSpeed; //velocidade do pulo;
    float gravity; //gravidade

    float groundPosition = 0; //posição do chão
    bool isGrounded = false; //verifica se o personagem está colidndo com o chão

    void Start()
    {
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;

        //Acima estamos usando as equações da cinemática para calcular a gravdiade e velocidade do pulo
        //Assim conseguimos ter controle da altura maxima e do tempo PT1

        groundPosition = transform.position.y; //posição do chão é igual a posição inicial do dinossauro
    }

    void Update()
    {
        yVelocity += gravity * Time.deltaTime * Vector2.down; //somando a gravidade na velocidade PT2

        if(transform.position.y <= groundPosition) //Se a posição no eixo Y do Dino for menor ou igual a do chão
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            //na posição atual acima, deixamos o x e z igual as posições atuais e passamos a do chão para o Y.
            yVelocity = Vector3.zero; //travando ele no eixo Y
            isGrounded = true; //significa que está colidindo com o chão.
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yVelocity = jumpSpeed * Vector2.up;
        }
        //Se a tecla Espaço for pressioanda e o personagem estiver colidndo com o chão, o Personagem irá pular PT4

        transform.position += (Vector3)yVelocity * Time.deltaTime; //somando a velocidade na posição do dino PT3
    }
}
