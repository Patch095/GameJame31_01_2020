using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ReadScoreboard : MonoBehaviour
{
    public string ScoreboardPath;   //scoreboardPath:   Assets/Scoreboard/GameJamScoreboard.txt

    public string[] Scoreboard;

    public int newScore;
    public string newName;
    public bool updateFile;

    public int NewPos;

    // Start is called before the first frame update
    void Start()
    {
        Scoreboard = ReadFile(ScoreboardPath);
    }

    private void Update()
    {
        if (updateFile)
        {
            OnGameEnd(newName, newScore);

            updateFile = false;
        }
    }

    static string[] ReadFile(string path)
    {
        StreamReader reader = new StreamReader(path);

        string[] textFile = File.ReadAllLines(path, Encoding.UTF8);

        int i = 0;
        foreach (string line in textFile)
        {
            textFile[i] = line.ToString();
            i++;
        }

        reader.Close();

        return textFile;
    }

    public void OnGameEnd(string playerName, int playerScore)
    {
        int playerNewPosition = CheckScore(playerScore, Scoreboard);

        NewPos = playerNewPosition;

        if(playerNewPosition > -1 && playerNewPosition < Scoreboard.Length)
        {
            AddNewScore(playerNewPosition, playerScore, playerName, Scoreboard);

            File.WriteAllText(ScoreboardPath, string.Empty);
            foreach(string str in Scoreboard)
            {
                WriteString(ScoreboardPath, str);
            }
        }
    }

    static int CheckScore(int newScore, string[] scoreboard)
    {
        int positionIndex;

        for(positionIndex = 1; positionIndex < 10; positionIndex++)
        {
            char[] scoreChar = new char[5];
            for(int i = 0; i < 5; i++)
            {
                scoreChar[i] = scoreboard[positionIndex][(scoreboard[positionIndex].Length - 5) + i];
            }
            string scoreString = new string(scoreChar);
            int scoreAtIndex;
            int.TryParse(scoreString, out scoreAtIndex);
            
            if(newScore > scoreAtIndex)
            {
                return positionIndex;
            }
        }

        return -1;
    }

    static void AddNewScore(int scoreIndex, int newScore, string playerName, string[] previuosLeadboard)
    {
        string[] newLeadboard = new string[previuosLeadboard.Length + 1];
        newLeadboard[0] = previuosLeadboard[0];

        string newLeadboardScore = scoreIndex.ToString() + ") " + playerName + " " + newScore.ToString().PadLeft(5, '0');
        int size = previuosLeadboard.Length;

        int index = 1;
        for (int i = index; i < size; i++)
        {           
            newLeadboard[i] = previuosLeadboard[index];
            if(i != scoreIndex)
            {
                index++;
            }
          
            string updateString = i.ToString();
            for(int c = 1; c < newLeadboard[i].Length; c++)
            {
                updateString += newLeadboard[i][c];
            }
            newLeadboard[i] = updateString;
        }

        newLeadboard[scoreIndex] = newLeadboardScore;

        for(int i = 0; i < size; i++)
        {
            previuosLeadboard[i] = newLeadboard[i];
        }

        //return newLeadboard;
    }

    static void WriteString(string path, string s)
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(s);
        writer.Close();
    }

    public string[] GetScoreboard()
    {
        return Scoreboard;
    }
}



/*
HIGHTSCORE:
1) AAA 00010
2) AAA 00007
3) AAA 00006
4) AAA 00005
5) AAA 00004
6) AAA 00003
7) AAA 00002
8) AAA 00001
9) AAA 00000
*/