using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject InGameUI;
    public GameObject ScoreboardMenuUI;
    public ReadScoreboard scoreboardMng;

    public GameObject CreditsMenu;

    public Text[] ScoreboardTexts;
    public Font font;

    public GameObject player;

    void OnEnable()
    {
        MainMenuUI.SetActive(true);
        InGameUI.SetActive(false);
        ScoreboardMenuUI.SetActive(false);
        CreditsMenu.SetActive(false);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameStart()
    {
        MainMenuUI.SetActive(false);
        InGameUI.SetActive(true);
        ScoreboardMenuUI.SetActive(false);
        CreditsMenu.SetActive(false);
        player.SetActive(true);
    }

    private void UpdateScoreboardMenu()
    {
        ScoreboardMenuUI.SetActive(true);

        string[] scoreboardText = scoreboardMng.GetScoreboard();
        for (int i = 0; i < scoreboardText.Length; i++)
        {
            ScoreboardTexts[i].font = font;
            ScoreboardTexts[i].text = scoreboardText[i];
        }
    }

    public void OpenScoreBoardMenu()
    {
        MainMenuUI.SetActive(false);
        InGameUI.SetActive(false);
        CreditsMenu.SetActive(false);

        //ScoreboardMenuUI.SetActive(true);
        UpdateScoreboardMenu();
    }
    public void CloseScoreBoardMenu()
    {
        MainMenuUI.SetActive(true);
        InGameUI.SetActive(false);
        ScoreboardMenuUI.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void OpenCreditsmenu()
    {
        MainMenuUI.SetActive(false);
        InGameUI.SetActive(false);
        ScoreboardMenuUI.SetActive(false);
        CreditsMenu.SetActive(true);
    }
    public void CloseCreditsmenu()
    {
        MainMenuUI.SetActive(true);
        InGameUI.SetActive(false);
        ScoreboardMenuUI.SetActive(false);
        CreditsMenu.SetActive(false);
    }
}
