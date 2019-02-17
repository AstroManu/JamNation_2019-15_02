using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionCard : MonoBehaviour {


    public int index = -1;


    public void OnPress()
    {


        for (int i = 0; i < transform.parent.childCount; i++) {


            if (transform.parent.GetChild(i) == transform)
                index = i;
        }

            Scr_ChoosingCards.instance.InstanceChosenCards(index);

    }
}
