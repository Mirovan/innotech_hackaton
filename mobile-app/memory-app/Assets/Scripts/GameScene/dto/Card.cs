using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public GameObject gameObject {get; set;}
    public CardStatus status {get; set;}

    public Card(GameObject gameObject, CardStatus status) {
        this.gameObject = gameObject;
        this.status = status;
    }
}
