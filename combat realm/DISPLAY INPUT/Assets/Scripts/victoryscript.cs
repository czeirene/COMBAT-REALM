using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class victoryscript : MonoBehaviour
{
    public TextMeshProUGUI winnerPlayer;
    public int winnerNum;

    void Awake()
    {
        winnerNum = nameshandler.displayer.winner;
    }
    void Start()
    {
        winnerTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winnerTitle()
    {
        if (winnerNum == 1)
        {
            winnerPlayer.text = nameshandler.displayer.playerName1;
        }

        else
        {
            winnerPlayer.text =nameshandler.displayer.playerName2;
        }
    }

     public void NextScene()
     {
        SceneManager.LoadScene(4);
     }
}
