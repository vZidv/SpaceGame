using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Ui : MonoBehaviour
{
    private Slider healthBoard;
    private Slider turboBoard;
    private GameObject level;
    public int startXp;
    public int Xp;
    private Text level_text;
    GameObject player;
    Player_Contol playerCont;
    void Start()
    {
        turboBoard = GameObject.Find("TurboBoard").GetComponent<Slider>();
        healthBoard = GameObject.Find("HealthBoard").GetComponent<Slider>();
        level = GameObject.Find("TextLevel");
        player = GameObject.FindGameObjectWithTag("Player");
        playerCont = player.GetComponent<Player_Contol>();
        level_text = level.GetComponent<Text>();

        healthBoard.maxValue = playerCont.health;
        turboBoard.maxValue = playerCont.turbo;
    }

    
    void Update()
    {
        level_text.text = "Level " + playerCont.Level;
        turboBoard.value = playerCont.turbo;
        healthBoard.value = playerCont.health;
    }
}
