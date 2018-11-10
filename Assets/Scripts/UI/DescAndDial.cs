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
        gameObject.SetActive(true);
        textDesc.gameObject.SetActive(true);
        nameTalker.gameObject.SetActive(false);
        portrait.gameObject.SetActive(false);
        nameTalker.text = "";
        textDesc.text = giveStep.grid[1, giveStep.y];
        portrait.sprite = null;
    }

    public void Dialogue(Step giveStep, Sprite imagePortrait)
    {
        gameObject.SetActive(true);
        textDesc.gameObject.SetActive(true);
        nameTalker.gameObject.SetActive(true);
        portrait.gameObject.SetActive(true);
        nameTalker.text = giveStep.grid[1, giveStep.y];
        textDesc.text = giveStep.grid[2, giveStep.y];
        portrait.sprite = imagePortrait;
    }

    public void Finish()
    {
        gameObject.SetActive(false);
        textDesc.gameObject.SetActive(false);
        nameTalker.gameObject.SetActive(false);
        portrait.gameObject.SetActive(false);
    }
}
