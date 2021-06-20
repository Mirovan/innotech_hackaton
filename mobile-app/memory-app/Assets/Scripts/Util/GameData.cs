using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public string score;
    public string name;

    public GameData(string score, string nameStr)
    {
    this.score = score;
    this.name = nameStr;
    }
}