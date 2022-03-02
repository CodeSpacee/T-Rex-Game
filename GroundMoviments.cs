using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoviments : MonoBehaviour
{
    public Sprite[] groundSprites; //array para pegar os sprites do chão diretamente da janela projects

    public SpriteRenderer[] grounds; //array do tipo sprite para referênciar todos os gameObjects ligados ao chão

    public float speed = 3; //velocidade da movimentação do chão

    Vector2 endPosition = new Vector2(-5.57f, -1.763881f); //posição final do chão
    Vector2 startPosition = new Vector2(3.99f, -1.76f); //posição inicial do chão

    void Start()
    {
        
    }

    void Update()
    {
        for(int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.position += Vector3.left * speed * Time.deltaTime;
            if(grounds[i].transform.position.x <= endPosition.x) //se a posição do chão for menor ou igual a posição final
            {
                gameController.instance.totalScore += 1; //atribuindo o valor da pontuação a váriavel pontuação total.
                gameController.instance.UpdateScoreText(); //chamando o método scoretext.
                grounds[i].transform.position = startPosition; //chão igual a posição inicial
                grounds[i].sprite = groundSprites[Random.Range(0, groundSprites.Length)]; 
                //através do método Random.Range os sprites serão gerados de maneira aletória.
            }
        }

        // O laço acima percorre cada gameoBject do chão e declara o movimento de ambos para a esquerda.
    }
}
