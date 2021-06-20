using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFinishOK : MonoBehaviour
{   
    public Button btn;
    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => {
            GameObject playerNameObj = GameObject.Find("InputFieldTextPlayerName");
            var inputField = playerNameObj.transform.GetComponent<UnityEngine.UI.InputField>();
            
            var score = GameObject.Find("TextScore").GetComponent<UnityEngine.UI.Text>().text;
            FileUtil.SaveFile(score, inputField.text);
            SceneChanger.goToStartScene();
        });
    }

}
