using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Ui : MonoBehaviour
{
    private Slider healthBoard;
    private Slider turboBoard;
    private GameObject level;
    private Text textXp;

    private Text level_text;
    GameObject player;
    Player_Contol playerCont;
    void Start()
    {   
        textXp = GameObject.Find("XpValue").GetComponent<Text>();
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
        textXp.text = playerCont.Xp+ "/" + playerCont.startXp;
        level_text.text = "Level " + playerCont.Level;
        turboBoard.value = playerCont.turbo;
        healthBoard.value = playerCont.health;
    }
     public void LevelUp()
     {
        StartCoroutine(LevelUpCor());
     }
    IEnumerator LevelUpCor()
    {
        Animator ani = level_text.gameObject.GetComponent<Animator>();
        ani.SetBool("LevelUp", true);
        yield return new WaitForSeconds(2f);
        ani.SetBool("LevelUp", false);
    }
}
