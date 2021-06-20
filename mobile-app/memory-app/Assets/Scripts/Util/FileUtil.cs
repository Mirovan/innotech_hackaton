using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileUtil {

    public static void SaveFile(string score, string name)
    {
        //Массив лучших игроков из файла
        List<GameData> gameDataList = LoadFile();

        string destination = Application.persistentDataPath + "/score.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
        } else {
            file = File.Create(destination);
        }

        //Текущий результат
        GameData data = new GameData(score, name);

        gameDataList.Add(data);

        gameDataList = gameDataList.OrderBy(item => item.score).ToList();
        if (gameDataList.Count > 10) {
            gameDataList = gameDataList.GetRange(0, 10);
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, gameDataList);
        file.Close();
    }

    public static List<GameData> LoadFile()
    {
        List<GameData> gameDataList = new List<GameData>();
        string destination = Application.persistentDataPath + "/score.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenRead(destination);
            BinaryFormatter bf = new BinaryFormatter();
            gameDataList = (List<GameData>) bf.Deserialize(file);
            gameDataList = gameDataList.OrderBy(item => item.score).Reverse().ToList();
            file.Close();
        } else {
            Debug.Log("File not found");
        }

        return gameDataList;
    }

}