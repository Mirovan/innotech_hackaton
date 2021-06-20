using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars
{
    //Число объектов
    private static int itemCount = 100;
    //Объекты
    public static List<IngredientItem> itemList;
    //последний индекс объекта который был показан
    public static int lastShowIndex;
    //последний индекс выбранного объекта (по нажатию кнопка)
    public static int lastChooseIndex;
    //Игра проиграна ?
    public static bool isLose;
    public static int score;

    static GlobalVars() {
        init();
    }

    public static void init() {
        lastShowIndex = 0;
        lastChooseIndex = -1;
        isLose = false;
        score = 0;

        itemList = new List<IngredientItem>();
        for (int i=0; i<itemCount; i++) {
            int rand = Random.Range(1, 6);
            itemList.Add(new IngredientItem("" + rand));
        }

        // string st = System.String.Empty;
        // for (int i = 0; i < GlobalVars.itemList.Count; i++) {
        //     st += GlobalVars.itemList[i].type + "; ";
        // }
        // Debug.Log("item = " + st);
    }
}
