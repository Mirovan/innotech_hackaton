using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void goToStartScene() {
        SceneManager.LoadScene(0);
    }

    public static void goToGameScene() {
        SceneManager.LoadScene(1);
    }

    public static void goToHighscoreScene() {
        SceneManager.LoadScene(2);
    }
}
