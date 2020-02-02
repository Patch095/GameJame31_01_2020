using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private string name;
    public string Name { get { return name; } }
    private int score;
    public int Score { get { return score; } }

    public void SetName(string newName)
    {
        name = newName;
    }
    public void UpdateScore(int point)
    {
        score += point;
    }

}
