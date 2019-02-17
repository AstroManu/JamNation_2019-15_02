using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_ChoosingCards : MonoBehaviour
{


    public static Scr_ChoosingCards instance;
    public GameObject cardTemplate;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public Sprite[] cardsArray;
    public HorizontalLayoutGroup pannelChosen;


    public void InstanceChosenCards(int index)
    {

        GameObject newCard = Instantiate  (cardTemplate, pannelChosen.transform);
        newCard.transform.GetChild(0).GetComponent<Image>().sprite = cardsArray[index];

    }
}
