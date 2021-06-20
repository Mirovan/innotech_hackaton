using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int score;
    public string name;

    public GameData(int scoreInt, string nameStr)
    {
    this.score = scoreInt;
    this.name = nameStr;
    }
}