using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIntro : MonoBehaviour {

    private void OnMouseDown()
    {
        GameManager.Instance.ui_holder.Click();
    }
}
