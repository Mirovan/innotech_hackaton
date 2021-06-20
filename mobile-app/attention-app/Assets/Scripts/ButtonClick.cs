using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonClick : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        // Button btn = btn1.GetComponent<Button>();
        btn = GetComponent<Button>();
		btn.onClick.AddListener(() => TaskOnClick(btn));
    }

    void TaskOnClick(Button button)
    {
        // Debug.Log("Clicked = " + button.name);

        string clickedBtnData = string.Empty;
        switch (button.name) {
            case "bt1":
                clickedBtnData = "1";
                break;
            case "bt2":
                clickedBtnData = "2";
                break;
            case "bt3":
                clickedBtnData = "3";
                break;
            case "bt4":
                clickedBtnData = "4";
                break;
            case "bt5":
                clickedBtnData = "5";
                break;
        }

        GlobalVars.lastChooseIndex++;

        if (GlobalVars.lastChooseIndex < GlobalVars.itemList.Count) {
            if (!GlobalVars.itemList[GlobalVars.lastChooseIndex].type.Equals(clickedBtnData)) {
                // GlobalVars.isLose = true;
                SceneManager.LoadScene(2);
                Debug.Log("False ->> lastChooseIndex = " + GlobalVars.lastChooseIndex + "; clicked=" + clickedBtnData + "; lastChooseIndex=" + GlobalVars.itemList[GlobalVars.lastChooseIndex].type);
            } else {
                GlobalVars.score++;
                Debug.Log("True ->> lastChooseIndex = " + GlobalVars.lastChooseIndex + "; clicked=" + clickedBtnData + "; lastChooseIndex=" + GlobalVars.itemList[GlobalVars.lastChooseIndex].type);
            }
        }
    }
}
