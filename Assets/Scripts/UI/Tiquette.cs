using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiquette : MonoBehaviour {
    
    public RectTransform rectT;
    public Text textT;
    public Button buttT;

    public Interaction inter;

    public void init(float pixelSize, int i, int fontSize, UnityEngine.Events.UnityAction action, Interaction interact)
    {
        rectT.sizeDelta = new Vector2(rectT.sizeDelta.x, pixelSize);
        rectT.localPosition = new Vector2(0, -pixelSize * i);
        rectT.anchoredPosition = new Vector2(0, rectT.anchoredPosition.y);
        textT.text = interact.id;
        textT.fontSize = fontSize;
        buttT.onClick.AddListener(action);
        inter = interact;
    }
    

}
