using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Holder : MonoBehaviour {

    public Choice_Holder choiceH;
    public DescAndDial desc;

    //Popup part
    public PopUp currentPopUp;
    public GameObject popUpPrefab;
    public float pixelSize;
    public float fontSize;

    //Reserve
    public List<Sprite> portraits;

	// Use this for initialization
	void Start () {
        pixelSize = Screen.height / 20;
        fontSize = pixelSize * 0.75f;   //for spacing 
    }
	

    public void Finish()
    {
        print("Yep, ça passe chez moi");
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

    public void LaunchChoice()
    {
        choiceH.LaunchChoice();
    }


    public void OpenPopUp(Vector2 position, List<Interaction> interactions)
    {
        if (currentPopUp == null)
            currentPopUp = Instantiate(popUpPrefab,this.transform).GetComponent<PopUp>();

        currentPopUp.init(position, interactions, pixelSize, fontSize);
    }



}
