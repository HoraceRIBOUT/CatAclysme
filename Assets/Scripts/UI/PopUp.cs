﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public float pixelSize;
    public float fontSize;

    public List<Tiquette> etiquettes = new List<Tiquette>();


    public Transform parentTiquette; 
    public GameObject etiquette;


    public List<Interaction> interactions = new List<Interaction>();

    // Use this for initialization
    void Start () {
        pixelSize = Screen.height / 20; 
        fontSize = pixelSize * 0.75f;   //for spacing 
        int size = interactions.Count;

        GameObject gO;
        Tiquette tiquette;
        RectTransform rectT = parentTiquette.GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2(rectT.sizeDelta.x, pixelSize * size);

        for (int i = 0; i < size; i++)
        {
            gO = Instantiate(etiquette, parentTiquette);
            tiquette = gO.GetComponent<Tiquette>();
            int value = i;
            tiquette.init(pixelSize, i, (int)fontSize, delegate { ClickOn(value); }, interactions[i]);
            etiquettes.Add(tiquette);
        }
        
    }

    void ClickOn(int indexHere)
    {
        GameManager.Instance.scenario.ExecutePath(etiquettes[indexHere].inter.pathToFollow);
        
    }
    



	
}
