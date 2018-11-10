using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Holder : MonoBehaviour {

    public Choice_Holder choiceH;
    public DescAndDial desc;

    //Popup part
    public PopUp currentPopUp;
    public GameObject popUpPrefab;



    public List<Sprite> portraits;

	// Use this for initialization
	void Start () {
		
	}
	

    public void Finish()
    {
        choiceH.Finish();
        desc.Finish();

    }

    public void Description(Step givenStep){
        desc.Description(givenStep);
    }

    public void Dialogue(Step givenStep)
    {
        int portraitNumber = int.Parse(givenStep.get(3));
        desc.Dialogue(givenStep, portraits[portraitNumber]);
    }

    public bool AddChoice(Step givenStep)
    {
        choiceH.AddChoice(givenStep);
        //verifier si dernier ou non
        return true;
    }

}
