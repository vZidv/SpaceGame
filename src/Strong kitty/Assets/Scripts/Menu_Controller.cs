using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public GameObject blackScrean;
    private Animator blackScreanAni;
    void Start()
    {
        blackScrean = GameObject.Find("BlackScrean");
        blackScrean.SetActive(false);      
        blackScreanAni = blackScrean.GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        StartCoroutine(PlayStart());
    }
    IEnumerator PlayStart()
    {
        blackScrean.SetActive(true);
        blackScreanAni.SetInteger("Status", 2);
        yield return new WaitForSeconds(1.4f);
        blackScreanAni.SetInteger("Status", 0);
        yield return new WaitForSeconds(1.4f);

        SceneManager.LoadScene("GameScene");
        yield return new WaitForSeconds(1.4f);
        blackScrean.SetActive(false);
    }
}
