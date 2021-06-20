using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class InitHighscoreScene : MonoBehaviour
{
    void Start()
    {
        // SceneManager.SetActiveScene(SceneManager.GetSceneByName("HighscoreScene"));

        var highscoreContainer = Resources.FindObjectsOfTypeAll<GameObject>()
                                            .FirstOrDefault(item => item.name.Equals("HighscoreContainer"))
                                            .transform;

        Transform row = highscoreContainer.Find("HighscoreRow");
        row.gameObject.SetActive(false);

        float templateHeight = 60f;

        List<GameData> gameDataList = FileUtil.LoadFile().OrderBy(item => item.score).ToList();
        for (int i=0; i<gameDataList.Count; i++) {
            var leader = gameDataList[i];
            Transform transformRow = Instantiate(row, highscoreContainer);
            transformRow.gameObject.SetActive(true);
            
            RectTransform rectTransform = transformRow.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -templateHeight*i);

            transformRow.Find("Place").GetComponent<UnityEngine.UI.Text>().text = (i+1).ToString();
            transformRow.Find("Score").GetComponent<UnityEngine.UI.Text>().text = leader.score.ToString();
            transformRow.Find("Name").GetComponent<UnityEngine.UI.Text>().text = leader.name;

            // Debug.Log(leader.name + " - " + leader.score);
        }
    }

}
