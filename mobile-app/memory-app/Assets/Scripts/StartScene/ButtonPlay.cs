using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{   
    public Button btn;
    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => {
            SceneChanger.goToGameScene();
        });
    }

}
