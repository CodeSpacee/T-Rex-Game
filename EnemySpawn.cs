using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    struct SpawnTime
    {
        public float instanceTime;
        public float interval;
        public float variation;
    }

    public Sprite[] cactusSprites; //array que guardará os sprites do cacto.

    public GameObject cactusPrefab; //referência oa prefab do cacto. Nãos e esqueça de passar o prefab pela Unity

    SpawnTime cactus; //Aqui declaramos um spawnTime ao cactus
    SpawnTime flying; //Aqui declaramos um spawnTime ao flying
    SpawnTime cloud; //Aqui declaramos um spawnTime ao cloud

    public GameObject flyingPrefab; //gameObject do flying

    float maxHeightFlying = 1;
    float minHeightFlying = -0.6f;

    public GameObject cloudPrfab;

    float maxHeightCloud = 0.8f; //altura maxima de spawn da nuvem
    float minHeightCloud = 0; //alrura minima de spawn da nuvem

    void Start()
    {
        cactus.instanceTime = 0; //tempo de instanciamento 
        cactus.interval = 2; //intervalo
        cactus.variation = 0.5f; //variação

        flying.instanceTime = 0; //tempo de instanciamento 
        flying.interval = 2; //intervalo
        flying.variation = 0.5f; //variação

        cloud.instanceTime = 0;
        cloud.interval = 1;
        cloud.variation = 0.3f;
    }

    void Update()
    {
        //sapwn cactus
        if(Time.time > cactus.instanceTime) //se o tempo for maior que o tempo de instanciamento
        {
            
            GameObject obj = Instantiate(cactusPrefab, new Vector3(-0.8371166f, -1.632411f), Quaternion.identity); //intanciando o objeto
            //passamos o prefab que corresponde ao objeto que será instanciado
            //posição em que o objeto será intanciado
            //rotação do objeto

            obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            //A função acima irá instanciar os sprites aleatóriamente.

            obj.AddComponent<BoxCollider2D>(); //a opção AddComponent nos permite adicionar componentes a objetos

            cactus.instanceTime = Time.time + Random.Range(cactus.interval - cactus.variation, cactus.interval + cactus.variation); 
            //o tempo de instanciamento é igual ao Tempo + uma variação entre o intervalo - a variação e intervalo + a variação 
        }
        //spawn flying
        if(Time.time > flying.instanceTime) //se o tempo for maior que o tempo de instanciamento
        {
            GameObject obj = Instantiate(flyingPrefab, new Vector3(-0.8371166f, Random.Range(maxHeightFlying, minHeightFlying)), Quaternion.identity); 
            //intanciando o objeto
            //passamos o prefab que corresponde ao objeto que será instanciado
            //posição em que o objeto será intanciado
            //rotação do objeto
            flying.instanceTime = Time.time + Random.Range(flying.interval - flying.variation, flying.interval + flying.variation); 
            //o tempo de instanciamento é igual ao Tempo + uma variação entre o intervalo - a variação e intervalo + a variação 
        }
        if(Time.time > cloud.instanceTime)//se o tempo for maior que o tempo de instanciamento
        {
            GameObject obj = Instantiate(cloudPrfab, new Vector3(-0.8371166f, Random.Range(maxHeightCloud, minHeightCloud)), Quaternion.identity);
            //intanciando o objeto
            //passamos o prefab que corresponde ao objeto que será instanciado
            //posição em que o objeto será intanciado
            //rotação do objeto
            cloud.instanceTime = Time.time + Random.Range(cloud.interval - cloud.variation, cloud.interval + cloud.variation);
            //o tempo de instanciamento é igual ao Tempo + uma variação entre o intervalo - a variação e intervalo + a variação 
        }
    }
}
