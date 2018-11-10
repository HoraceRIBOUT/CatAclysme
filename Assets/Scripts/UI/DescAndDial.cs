using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescAndDial : MonoBehaviour {

    public Text textDesc;
    public Text nameTalker;
    public Image portrait;



    public string currentText = "";
    public string currentName = "";
    public Sprite currentPortrait;


    public void Description(Step giveStep)
    {
        nameTalker.text = "";
        textDesc.text = giveStep.grid[1, giveStep.y];
        portrait.sprite = null;
    }

    public void Dialogue(Step giveStep, Sprite imagePortrait)
    {
        nameTalker.text = giveStep.grid[1, giveStep.y];
        textDesc.text = giveStep.grid[2, giveStep.y];
        portrait.sprite = imagePortrait;
    }

    public void Finish()
    {

    }
}
