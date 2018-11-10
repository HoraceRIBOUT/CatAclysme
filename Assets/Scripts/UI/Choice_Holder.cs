using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice_Holder : MonoBehaviour {

    private Text[] choice = new Text[4];
    private string[] csv = new string[4];
    private int choiceCount = 0;


	// Use this for initialization
	void Start () {
		
	}

    public void AddChoice(Step givenStep)
    {
       if(choiceCount != 4)
       {
            csv[choiceCount] = givenStep.get(2);
            choice[choiceCount].text = givenStep.get(1);
            choice[choiceCount].transform.parent.gameObject.SetActive(true);
            choiceCount++;
       }
       else
       {
            Debug.LogError("ERREUR ! TROP DE CHOIX BZZT MORT DE L'ESPRIT");
       }

    }

    public void LaunchChoice()
    {
        //set to true significant part
    }

    public void ChoosenChoice(int clickedIndex)
    {
        GameManager.Instance.scenario.ExecutePath(csv[clickedIndex]);
        for (int index = 0; index < choiceCount; index++ )
        {
            choice[index].transform.parent.gameObject.SetActive(false);
            csv[index] = "";
        }
        choiceCount = 0;
    }

    public void Finish()
    {
        //set to false all part
    }
}
