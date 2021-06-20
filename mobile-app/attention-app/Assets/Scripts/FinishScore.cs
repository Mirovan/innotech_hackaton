using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScore : MonoBehaviour
{
    private UnityEngine.UI.Text scoreObj;

    void Start()
    {
        scoreObj = GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        scoreObj.text = "Your score: " + GlobalVars.score;
    }

}
