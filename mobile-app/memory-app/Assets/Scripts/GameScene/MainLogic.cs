using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MainLogic : MonoBehaviour
{
    //задержка при перевороте неправильных карточек обратно
    private float delayTime = 0;
    //окончена ли игра
    private bool isEnd = false;
    //результат
    private long score;
    void Update()
    {
        //если все карточки открыты
        if (GlobalVars.flippedRightCount == 16 && !isEnd) {
            isEnd = true;
            //Результат
            score = (DateTime.Now.Ticks - GlobalVars.startTime) / (100 * 1000);
        }

        //если игра окончена
        if (isEnd) {
            //показываем панель выигрыша
            var panel = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(item => item.name.Equals("PanelBackground"));
            panel.SetActive(true);
            //показываем подложку чтобы карты не были доступны для клика
            var podlojka = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(item => item.name.Equals("PlaneHider"));
            podlojka.SetActive(true);

            //Отображение результата
            GameObject scoreObj = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(item => item.name.Equals("TextScore"));
            scoreObj.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }


        //Открыты 2 карточки
        if (GlobalVars.currentFlippedObjects.Count == 2) {
            //Если обе карточки перевернуты картинками вверх
            if (GlobalVars.currentFlippedObjects[0].status == CardStatus.flipped
                    && GlobalVars.currentFlippedObjects[1].status == CardStatus.flipped) {

                var mat1 = GlobalVars.currentFlippedObjects[0].gameObject.transform.Find("Quad").GetComponent<Renderer>().material;
                var mat2 = GlobalVars.currentFlippedObjects[1].gameObject.transform.Find("Quad").GetComponent<Renderer>().material;

                //Открыты одинаковые карточки
                if (mat1.name.Equals(mat2.name)) {
                    GlobalVars.flippedRightCount += 2;
                    GlobalVars.currentFlippedObjects.Clear();
                }
                //Если карточки перевернуты обе картинками вверх - разворачиваем обратно
                else {
                    //Задержка - держим на экране некоторое врем прежде чем перевернуть обратно
                    if (delayTime > GlobalVars.waitingTimeWrongFlip) {
                        GlobalVars.currentFlippedObjects[0].status = CardStatus.closing;
                        GlobalVars.currentFlippedObjects[1].status = CardStatus.closing;
                        TileBox.rotateCard(GlobalVars.currentFlippedObjects[0].gameObject.transform);
                        TileBox.rotateCard(GlobalVars.currentFlippedObjects[1].gameObject.transform);
                        GlobalVars.currentFlippedObjects.Clear();
                        delayTime = 0;
                    }
                    delayTime += 1;
                }
                
            }
        }

    }
}
