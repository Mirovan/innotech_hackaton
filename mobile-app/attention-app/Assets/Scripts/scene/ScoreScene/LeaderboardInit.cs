using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardInit : MonoBehaviour
{
    void Start()
    {
        Transform transformContainer = transform.Find("HighscoreContainer");
        // Debug.Log("transformContainer: " + transformContainer);

        Transform transformTemplateRow = transformContainer.Find("HighscoreRow");
        transformTemplateRow.gameObject.SetActive(false);

        float templateHeight = 60f;

        List<GameData> gameDataList = ScoreUtil.LoadFile();
        for (int i=0; i<gameDataList.Count; i++) {
            var leader = gameDataList[i];
            Transform transformRow = Instantiate(transformTemplateRow, transformContainer);
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
