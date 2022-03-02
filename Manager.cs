using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importando a bibiloteca de cenas

public class Manager : MonoBehaviour
{
   Dino dino; //script do Dinossauro
   EnemySpawn enemy_spawn; //script de spawn do cacto
   GroundMoviments ground_moviments; //script de movimentação do chão

   bool gameOver = false; //váriavel que determina se o Player perdeu


    void Start()
    {
        dino = FindObjectOfType<Dino>(); //A função FindObjectOfType<>() nos permite pegar componentes de acordo com o seu tipo
        enemy_spawn = FindObjectOfType<EnemySpawn>();
        ground_moviments = FindObjectOfType<GroundMoviments>();  

    }

 
    void Update()
    {
        if(!gameOver)
        {
            if(Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, LayerMask.GetMask("Enemy")).Length > 0)
            {
                //a posição passada foi a posição do dino, atribuimos um tamanho
                //e a layer especifica neste caso e a layer enemy que corresponde  alayer do inimigo (cacto)
                //devemos criar uma layer Enemy e adicionar o prefab do cacto a ela.
                
                ground_moviments.speed = 0; //pegando a váriavel speed do script GroundMoviments, ela deve ser publica para funcionar

                gameOver = true; //tornando o gameOver verdadeiro se colidir com
                //a layer Enemy

                Cactus[] allCactus = FindObjectsOfType<Cactus>(); //pegando os objetos do tipo Cactus
                //usamos o s no Object"s" quando queremos pegar mais d eum obejto.
                Flying[] allFlying = FindObjectsOfType<Flying>();

                foreach (Cactus obj in allCactus)
                    obj.speed = 0; //a váriavel speed do script do Cactus também deve ser publica

                foreach (Flying obj in allFlying)
                    obj.speed = 0; 
            }
        }
        else
        {
            //Restart
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0); //restart
            }
        }   
    }
}
