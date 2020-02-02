using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class main : MonoBehaviour
{
    static float timer_duration = 180f;

    public float CurrentTimer { get { return CurrentTimer; } }
    float currentTimer;

    bool is_game_started;

    public Transform time_image;

    public ReadScoreboard ScoreboardMng;
    public UImanager UImng;
    public AudioClip GameSoundTrack;
    AudioSource audio;

    //aggiungere player
    public GameObject player;
    PlayerScore playerScore;

    public GameObject InputNameMenu;
    public Text Text;
    bool goToScoreboard;

    public GameObject playerController;

    void OnEnable()
    {
        is_game_started = false;
        goToScoreboard = false;

        playerScore = player.GetComponent<PlayerScore>();

        InputNameMenu.SetActive(false);

        //audio
        audio = GetComponent<AudioSource>();

        playerController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_game_started && currentTimer > 0)
        {
            //get player input

            currentTimer -= Time.deltaTime;

            float time_remain = currentTimer / timer_duration;
            Mathf.Clamp01(time_remain);
            time_image.localScale = new Vector3(time_remain, 1, 1);
        }
        else if(currentTimer <= 0 && is_game_started)
        {
            //aprire menu name

            //InputNameMenu.SetActive(true);

            //if menu name button chiama on game end
        }

        if (goToScoreboard)
        {
            char[] c = new char[3];
            c[0] = Text.text[Text.text.Length - 3];
            c[1] = Text.text[Text.text.Length - 2];
            c[2] = Text.text[Text.text.Length - 1];

            playerScore.SetName(new string(c));
            ScoreboardMng.OnGameEnd(playerScore.Name, playerScore.Score);
            UImng.OpenScoreBoardMenu();
        }
    }

    public void StartGame()
    {
        if(is_game_started == false)
        {           
            is_game_started = true;
            currentTimer = timer_duration;
            audio.Play();

            playerController.SetActive(true);
        }
    }

    public void OnGameEnd()
    {
        goToScoreboard = true;
        //playerScore.SetName(Text.text);
        //ScoreboardMng.OnGameEnd(playerScore.Name, playerScore.Score);
        //UImng.OpenScoreBoardMenu();
    }

    public void Quit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
