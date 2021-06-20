using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBox : MonoBehaviour
{
    private static float speed = 300f;

    private Card card; //Описывает саму текущую карточку

    void OnMouseDown()
    {
        if (card.status == CardStatus.closed) {
            if (GlobalVars.currentFlippedObjects.Count < 2) {
                //Проверка чтобы дважды не добавить объект при двойном клике
                if (GlobalVars.currentFlippedObjects.Count == 0
                    || (GlobalVars.currentFlippedObjects.Count == 1 && !GlobalVars.currentFlippedObjects[0].Equals(card))) {
                    card.status = CardStatus.opening;
                    GlobalVars.currentFlippedObjects.Add(card);
                }
            }
        }
    }

    void Start() {
        card = new Card(transform.gameObject, CardStatus.closed);
    }

    void Update() {
        if (card != null) {
            //Открытие карточки
            if (card.status == CardStatus.opening) {
                rotateCard(transform);
                if (transform.rotation.eulerAngles.y >= 180) {
                    this.card.status = CardStatus.flipped;
                }
            }

            //Закрытие карточки
            if (card.status == CardStatus.closing) {
                float prevAngle = transform.rotation.eulerAngles.y;
                rotateCard(transform);
                float currentAngle = transform.rotation.eulerAngles.y;
                
                //Случился переход через 0 - полный оборот
                if (prevAngle > currentAngle) {
                    this.card.status = CardStatus.closed;
                }
            }
        }
    }

    
    /**
        Открытие карточки
    */
    public static void rotateCard(Transform trans) {
        trans.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * speed));
    }

}
