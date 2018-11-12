using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Zone : MonoBehaviour {

    public string id;
    public GameObject halo;

    public List<Interaction> interactions = new List<Interaction>();


    public bool ULTRAENDDONTTOUCHIT = false;

    public bool alreadyPressOnce = false;

    private void OnMouseEnter()
    {
        GameManager.Instance.scenario.nbrZoneSous++;
    }

    private void OnMouseExit()
    {
        GameManager.Instance.scenario.nbrZoneSous--;
    }


    private void OnMouseUp()
    {
        if (GameManager.Instance.scenario.currentZone != this && !GameManager.Instance.scenario.readingCSV && !alreadyPressOnce)
        {
            alreadyPressOnce = true;
            print("Call call call "+this.name + " ---" + this.id);
            StartCoroutine(waitForEnd());
        }


        if (ULTRAENDDONTTOUCHIT)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    IEnumerator waitForEnd()
    {
        yield return new WaitForEndOfFrame();
        if (!GameManager.Instance.scenario.readingCSV)
        {
            GameManager.Instance.scenario.currentZone = this;
            GameManager.Instance.ui_holder.OpenPopUp(Input.mousePosition, interactions);
        }
        alreadyPressOnce = false;
    }

}
