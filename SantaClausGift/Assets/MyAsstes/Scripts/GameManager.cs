using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject panelObjs;

    public Text boxCntTxt;
    public Text starCntTxt;

    public static int boxCnt;
    public static int starCnt;

    public GameObject gameoverMenu;
    public GameObject objectivesMenu;
    public GameObject tapStartBtn;
    public GameObject player;
    private static PlayerScript playerManager;

    public static PlayerScript PlayerManager
    {
        get
        {
            if (playerManager == null)
            {
                playerManager = GameObject.FindObjectOfType<PlayerScript>();
            }
            return playerManager;
        }

        set
        {
            playerManager = value;
        }
    }

    // Use this for initialization
    private void Start()
    {
        player = GameObject.Find("Player");
        PlayerScript._speed = 0;
        PlayerManager = GetComponent<PlayerScript>();

        objectivesMenu.SetActive(true);
      
    }

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            ObjetiveManager(1);
        }
        boxCntTxt.text = boxCnt.ToString();
        starCntTxt.text = starCnt.ToString();

        if (objectivesMenu.activeSelf)
        {
            PlayerManager.enabled = false;
        }
        else 
        {
            PlayerManager.enabled = true;
        }
    }

    public void SceneManager(string scene)
    {
        switch (scene)
        {
            case "Menu":
                Application.LoadLevel(0);
                break;
            case "Level":
                Application.LoadLevel(1);
                break;
            case "Gameplay":
                Application.LoadLevel(2);
                break;
            case "GameOver":
                gameoverMenu.SetActive(true);
                PlayerManager.currentScoreText.text = PlayerManager.score.ToString();

                int bestScore = PlayerPrefs.GetInt("BestScore", 0);

                if (PlayerManager.score > bestScore)
                {
                    PlayerPrefs.SetInt("BestScore", PlayerManager.score);
                }

                PlayerManager.bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

                break;
        }
    }

    public void Manager(bool toStart)
    {
        if (toStart)
        {
            PlayerScript._speed =  player.GetComponent<PlayerScript>().speed;
            tapStartBtn.SetActive(false);
        }
    }

    public static void ObjetiveManager(int objNumber)
    {
        switch (objNumber)
        {
            case 1:


                if (boxCnt >= 3 && starCnt >= 3 && PlayerManager.score == 100)
                {
                    print("WIN!");
                }
                else
                {
                    print("Lose");
                }
                break;
        }
    }

    public void DesactiveUI(string ui)
    {
        switch (ui)
        {
            case "ObjMenu":
                objectivesMenu.SetActive(false);
                break;    
        }
    }
}
