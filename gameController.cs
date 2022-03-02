using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public int totalScore; //pontuação total
    public static gameController instance; //Nos permite acessar este script através de outros scripts
    public Text scoreText; //para pegarmos o objeto d etexto do UI

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString(); //convertendo o total score para string e o atribuindo ao texto do UI
    }
}
