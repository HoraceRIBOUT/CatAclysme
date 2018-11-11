using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

    public GameObject halo;

    public List<Interaction> interactions = new List<Interaction>();

    void OnMouseOver()
    {
        //halo.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.scenario.currentZone != this && !GameManager.Instance.scenario.readingCSV)
        {
            GameManager.Instance.scenario.currentZone = this;
            GameManager.Instance.ui_holder.OpenPopUp(Input.mousePosition, interactions);
        }

    }
}
