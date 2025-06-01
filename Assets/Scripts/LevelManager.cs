using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public GameObject[] MyPanels;
    public int Level = 0;
    public Button[] Levels;

    private const string MyLevels = "LevelKey";

    public GameObject Menu;
    public GameObject LevelsPanel;
    public GameObject ConvertPanel;

    private void Start()
    {
        Level = PlayerPrefs.GetInt(MyLevels, Level);
        SaveLevel();
        LevelStage();
        LevelShow();
    }
    public void GameScene()
    {
        SceneManager.LoadScene("SeaGameScene");
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(MyLevels, Level);
        PlayerPrefs.Save();
    }

    public void LevelStage()
    {
        if (SceneManager.GetActiveScene().name == "SeaMainMenu")
        {
            Levels[Level].interactable = true;
            if (Level >= 1)
            {
                Levels[Level - 1].interactable = false;
            }
        }
    }

    public void LevelShow()
    {
        MyPanels[Level].gameObject.SetActive(true);
    }

    public void Panel1()
    {
        if (LevelsPanel.activeSelf)
        {
            LevelsPanel.gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
        }
        else
        {
            LevelsPanel.gameObject.SetActive(true);
            Menu.gameObject.SetActive(false);

        }
    }
    public void Panel2()
    {
        if (ConvertPanel.activeSelf)
        {
            ConvertPanel.gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
        }
        else
        {
            ConvertPanel.gameObject.SetActive(true);
            Menu.gameObject.SetActive(false);

        }
    }

}
