using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void goToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void goToGame() {
        GlobalVars.init();
        SceneManager.LoadScene(1);
    }

    public void goToGameOver() {
        SceneManager.LoadScene(2);
    }

    public void goToStatistics() {
        SceneManager.LoadScene(3);
    }
}
