using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Ui : MonoBehaviour
{
    private Slider healthBoard;
    private Slider turboBoard;
    private GameObject level;
    private Text textXp;

    [Header("Weapons")]
    public GameObject shotGun;
    public GameObject Lazer;

    public GameObject shotGunShop;
    public GameObject LazerShop;
    [Header("Screans")]
    public GameObject LevelUpScrean;
    public GameObject pauseScraean;
    public GameObject deadScrean;

    private Text level_text;
    GameObject player;
    Player_Contol playerCont;

    bool pause = false;
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
        if(Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            pauseScraean.SetActive(true);
            Time.timeScale = 0.001f;
            pause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            pauseScraean.SetActive(false);
            Time.timeScale = 1;
            pause = false;
        }

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
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
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
        LevelUpScrean.gameObject.transform.Find("Board").Find("Level_Ship").Find("Level_Value").GetComponent<Text>().text = $"{playerCont.levelShip}";

        if (playerCont.levelShip == 1)
            LevelUpScrean.gameObject.transform.Find("Board").Find("Level_Ship").Find("Text_warning").GetComponent<Text>().text =  $"You need level {playerCont.levelShip_2} for this upgrade";
        else if (playerCont.levelShip == 2)
            LevelUpScrean.gameObject.transform.Find("Board").Find("Level_Ship").Find("Text_warning").GetComponent<Text>().text = $"You need level {playerCont.levelShip_3} for this upgrade";

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
    public void ShotGunUnlock()
    {
        if (playerCont.levelShip >= 2)
        {
            Player_Weapon player_Weapon = playerCont.gameObject.GetComponent<Player_Weapon>();
            player_Weapon.inventory[1] = player_Weapon.allWeapon[1];
            shotGun.SetActive(true);
            shotGunShop.SetActive(false);
            endUpGrade();
        }
    }
    public void LazerUnlock()
    {
        if (playerCont.levelShip >= 3)
        {
            Player_Weapon player_Weapon = playerCont.gameObject.GetComponent<Player_Weapon>();
            player_Weapon.inventory[2] = player_Weapon.allWeapon[2];
            Lazer.SetActive(true);
            LazerShop.SetActive(false);
            endUpGrade();
        }
    }
    public void DamageUp()
    {
            playerCont.gameObject.GetComponent<Player_Weapon>().damageBonus += 1;
            endUpGrade();
           
    }
    public void UpgradeShip()
    {
        if(playerCont.Level >= playerCont.levelShip_2 && playerCont.levelShip == 1)
        {
            playerCont.gameObject.transform.Find("ViewShip").Find("Ship_Lv2").gameObject.SetActive(true);
            playerCont.gameObject.transform.Find("Effects").gameObject.transform.position = playerCont.gameObject.transform.Find("Level2Point").gameObject.transform.position;
            playerCont.healthStart += 5;
            playerCont.turboStart += 3;
            playerCont.gameObject.GetComponent<Player_Weapon>().speedRotation = 2.5f;
            CapsuleCollider2D collider = playerCont.gameObject.GetComponent<CapsuleCollider2D>();
            collider.offset = new Vector3( 0,-0.94f);
            collider.size = new Vector2(2.2f, 3.12f);
            playerCont.levelShip = 2;
            //0.17

            //1.17
            //1.34
            endUpGrade();
        }
        else if(playerCont.Level >= playerCont.levelShip_3 && playerCont.levelShip == 2)
        {
            playerCont.gameObject.transform.Find("ViewShip").Find("Ship_Lv3").gameObject.SetActive(true);
            playerCont.gameObject.transform.Find("Effects").gameObject.transform.position = playerCont.gameObject.transform.Find("Level3Point").gameObject.transform.position;
            playerCont.healthStart += 5;
            playerCont.turboStart += 3;
            playerCont.gameObject.GetComponent<Player_Weapon>().speedRotation = 2f;
            CapsuleCollider2D collider = playerCont.gameObject.GetComponent<CapsuleCollider2D>();
            collider.offset = new Vector3(0, -1.47f);
            collider.size = new Vector2(3.41f, 3.47f);
            playerCont.levelShip = 3;
            //0.17

            //1.17
            //1.34
            endUpGrade();
        }
    }
    private void endUpGrade()
    {
        LevelUpScrean.SetActive(false);
        Time.timeScale = 1;
    }
}
