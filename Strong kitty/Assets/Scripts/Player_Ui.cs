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

    [Header("Screans")]
    public GameObject LevelUpScrean;
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

        LevelUpScrean.SetActive(false);
    }

    
    void Update()
    {
        healthBoard.maxValue = playerCont.healthStart;
        turboBoard.maxValue = playerCont.turboStart;

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
        yield return new WaitForSeconds(1f);
        LevelUpScrean.SetActive(true);

        LevelUpScrean.gameObject.transform.Find("Board").Find("Health").Find("Health_Value").GetComponent<Text>().text = $"{playerCont.healthStart}";
        LevelUpScrean.gameObject.transform.Find("Board").Find("Turbo").Find("Turbo_Value").GetComponent<Text>().text = $"{playerCont.turboStart}";
        LevelUpScrean.gameObject.transform.Find("Board").Find("Damage").Find("Damage_Value").GetComponent<Text>().text = $"{playerCont.gameObject.GetComponent<Player_Weapon>().damageBonus}";

        Time.timeScale = 0f;
        yield return new WaitForSeconds(1f);
        ani.SetBool("LevelUp", false);
    }
    public void HealthUp()
    {
        playerCont.healthStart += 5;
        endUpGrade();
    }
    public void TurboUp()
    {
        playerCont.turboStart += 2;
        endUpGrade();
    }
    public void DamageUp()
    {
        playerCont.gameObject.GetComponent<Player_Weapon>().damageBonus += 1;
        endUpGrade();
    }
    private void endUpGrade()
    {
        LevelUpScrean.SetActive(false);
        Time.timeScale = 1;
    }
}
