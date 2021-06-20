using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{

    public void saveScore() {
        GameObject playerNameObj = GameObject.Find("TextPlayerNameField");
        var inputField = playerNameObj.transform.GetComponent<UnityEngine.UI.InputField>();
        ScoreUtil.SaveFile(GlobalVars.score, inputField.text);
    }

}
