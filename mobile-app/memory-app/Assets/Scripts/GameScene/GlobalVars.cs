using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalVars : MonoBehaviour
{
    //Текущие открытые карточки (может быть только 2, потом переворачиваются)
    public static List<Card> currentFlippedObjects;
    //Число правильно открытых карточек
    public static int flippedRightCount;
    //число тиков - задержка для переворота неправильных карточек обратно
    public static int waitingTimeWrongFlip = 5;
    //время на раунд
    public static long startTime;

    public static void init() {
        currentFlippedObjects = new List<Card>();
        flippedRightCount = 0;
        startTime = DateTime.Now.Ticks;
    }
}
