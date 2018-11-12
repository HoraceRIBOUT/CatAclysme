using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {


    public EnumUtils.textAvailable startFile;

    [Header("RoomMode")]
    public List<Room> rooms = new List<Room>();
    public Zone currentZone = null;
    //Instanciate each one, by vague probably, or at start


    [Header("CSV reading")]
    public bool readingCSV = true;
    public bool waitingForClick = false;

    public EnumUtils.textAvailable pathOfNextCSV;
    public TextAsset nextCSVToRead;
    public List<Step> currentStepList = new List<Step>();
    public int currentPos = 0;

    [Header("Progression")]
    public Dictionary<string, bool> dicoBool = new Dictionary<string, bool>();
    public List<string> _debug_NameCond = new List<string>();

    public List<string> inventaire; 


    // Use this for initialization
    void Start () {
       
    }

    public void EndOfIntro()
    {
        if (!GameManager.Instance._FEBUG_dont_start_with_startCVS)
        {
            if ((int)pathOfNextCSV == 0)
                pathOfNextCSV = startFile;
            TreatCSV();
        }
    }

    public int nbrZoneSous = 0;
    public GameObject mouseMouse;
	// Update is called once per frame
	void Update () {
        if (waitingForClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                waitingForClick = false;
                GameManager.Instance.sonMaster.JoueBruitage((int)Utils.BruitageName.Clique, false);
                displayNextStep();
            }
        }

        Vector3 mousePos = GameManager.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 2f;
        mouseMouse.transform.position = mousePos;

        MouseOnSomething();

    }
    
    public void MouseOnSomething()
    {
        ///test si something sous la souris. Si oui : 
        ///
        if (nbrZoneSous < 0)
            nbrZoneSous = 0;
        mouseMouse.GetComponent<Animator>().SetBool("Something", nbrZoneSous!=0);
    }


    private void TreatCSV()
    {
        currentPos = -1;
        currentStepList.Clear();
        /*choiceWaiting.Clear();
        choiceOnScreen = false;
        imageHolder.GoBack();
        choiceBoxes.gameObject.SetActive(false);
        boxText.gameObject.SetActive(true);*/
        //CHOICE are going to handle himself (behave a little, choice !)
        
        //Debug.Log("stringPath=" + "Path/" + stringPath);
        nextCSVToRead = (TextAsset)Resources.Load("Path/" + pathOfNextCSV);
        if (nextCSVToRead == null)
            print("Yep, null");
        Debug.Log("Csv = " + nextCSVToRead.name);
        Debug.Log(" original path (without Path/) = " + pathOfNextCSV);

        string[,] grid = CSV_Reader.SplitCsvGrid(nextCSVToRead.text);
        Step bufferStep = null;
        for (uint y = 0; y < grid.GetUpperBound(1); y++)
        {
            Debug.Log("y ?" + y);
            bufferStep = new Step(grid, y);
            currentStepList.Add(bufferStep);
        }
        readingCSV = true;
        nbrZoneSous = 0;
        displayNextStep();
    }

    private void displayNextStep()
    {
        currentPos++;
        if (currentPos >= currentStepList.Count)
        {
            EndCSVreading();
            return;
        }

        Step currentStep = currentStepList[currentPos];
        Utils.StepType typeToTreat = currentStep.type;
        print("Pos " + currentPos + 
              " listSize = " + currentStepList.Count + 
              " name ? " + typeToTreat.ToString());

        //THE BIG SWITCH !!!
        switch (typeToTreat)
        {
            case (Utils.StepType.Description):
                DisplayDescription(currentStep);
                break;
            case (Utils.StepType.Dialogue):
                DisplayDialogue(currentStep);
                break;
            case (Utils.StepType.Choix):
                DisplayChoice(currentStep);
                break;
            case (Utils.StepType.Animation):
                DisplayAnimation(currentStep);
                break;
            case (Utils.StepType.Bruitage):
                DisplayBruitage(currentStep);
                break;
            case (Utils.StepType.Musique):
                DisplayMusique(currentStep);
                break;
            case (Utils.StepType.Salle):
                DisplaySalle(currentStep);
                break;
            case (Utils.StepType.Decor):
                DisplayDecor(currentStep);
                break;
            case (Utils.StepType.Next):
                DisplayNext(currentStep);
                break;
            case (Utils.StepType.Condition):
                DislayCondition(currentStep);
                break;
            case (Utils.StepType.ChangeValeur):
                DisplayValeur(currentStep);
                break;
            case (Utils.StepType.ChangeZone):
                DisplayZone(currentStep);
                break;
            case (Utils.StepType.ChangeInteraction):
                DisplayInteraction(currentStep);
                break;
            case (Utils.StepType.AddItem):
                DisplayAddItem(currentStep);
                break;
            case (Utils.StepType.RemoveItem):
                DisplayRemoveItem(currentStep);
                break;
            default:
                Debug.LogError("CustomError : Can't treat this type : " + typeToTreat.ToString());
                break;
        }

    }

    public void EndCSVreading()
    {
        readingCSV = false;
        print("Reçu ? Reçu ? Reçu ?!");
        GameManager.Instance.ui_holder.Finish();
    }



    private void DisplayDescription(Step giveStep)
    {
        GameManager.Instance.ui_holder.Description(giveStep);
        waitingForClick = true;
    }

    private void DisplayDialogue(Step giveStep)
    {
        GameManager.Instance.ui_holder.Dialogue(giveStep);
        waitingForClick = true;
    }

    private void DisplayChoice(Step giveStep)
    {
        if(currentPos == currentStepList.Count)
        {
            GameManager.Instance.ui_holder.LaunchChoice();
        }
        else
        {
            displayNextStep();
        }
    }

    public void ExecutePath(EnumUtils.textAvailable returningValue)
    {
        pathOfNextCSV = returningValue;
        TreatCSV();
    }

    private void DisplayNext(Step giveStep)
    {
        pathOfNextCSV = EnumUtils.ChangeToEnum(giveStep.get(1));
        TreatCSV();
    }

    //NOPE
    private void DisplayAnimation(Step giveStep)
    {

        displayNextStep();
    }

    private void DisplayBruitage(Step giveStep)
    {
        int indexOfMusique = (int)Utils.stringToBruitageName(giveStep.get(1));
        bool random = (giveStep.get(2) == "TRUE");
        GameManager.Instance.sonMaster.JoueBruitage(indexOfMusique, random);
        displayNextStep();
    }

    private void DisplayMusique(Step giveStep)
    {
        int indexOfMusique = (int)Utils.stringToMusiqueName(giveStep.get(1));
        float delay;
        if( !float.TryParse(giveStep.get(2), out delay))
        {
            delay = 1.5f;
        }
        GameManager.Instance.sonMaster.ChangeMusique(indexOfMusique, delay);
        displayNextStep();
    }

    public Animator animatorCanvas;
    public Room currentRoom = null;
    public Room nextRoom = null;
    private void DisplaySalle(Step giveStep)
    {
        animatorCanvas.SetTrigger("Transition");

        string roomID = giveStep.get(1); 
        foreach (Room r in rooms)
        {
            if (r.id == roomID)
            {
                nextRoom = r;
            }
        }
        nbrZoneSous = 0;
        Invoke("ChangeRoom", 1f);
        Invoke("FollowTransition", 2f);
    }

    private void ChangeRoom()
    {
        currentRoom.gameObject.SetActive(false);
        currentRoom = nextRoom;
        currentRoom.gameObject.SetActive(true);
    }
    private void FollowTransition()
    {
        displayNextStep();
    }

    //Nope
    private void DisplayDecor(Step giveStep)
    {
        displayNextStep();
    }

    private void DisplayValeur(Step giveStep)
    {
        string value = giveStep.get(1);
        bool key = giveStep.get(2) == "TRUE";
        if (dicoBool.ContainsKey(value))
        {
            dicoBool[value] = key;
            _debug_NameCond.Add(value+key);
        }
        else
            dicoBool.Add(value, key);
        displayNextStep();
    }

    private void DislayCondition(Step giveStep)
    {
        string index = giveStep.get(1);
        bool res;
        /*res = */dicoBool.TryGetValue(index, out res);
        Debug.Log("Cond is on : " + index);
        if (res)
        {
            ExecutePath(EnumUtils.ChangeToEnum(giveStep.get(2)));
        }
        else
        {
            ExecutePath(EnumUtils.ChangeToEnum(giveStep.get(3)));
        }
    }

    private void DisplayZone(Step giveStep)
    {
        DesactiveZoneDansRoom(giveStep.get(1), giveStep.get(2), giveStep.get(3)=="TRUE");
        displayNextStep();
    }

    private void DisplayInteraction(Step giveStep)
    {
        //.???
        displayNextStep();
    }

    private void DesactiveZoneDansRoom(string roomID, string zoneID, bool value)
    {
        foreach (Room r in rooms)
        {
            if(r.id == roomID)
            {
                r.setActiveZone(zoneID, value);
                return;
            }

        }
    }


    private void DisplayAddItem(Step giveStep)
    {
        inventaire.Add(giveStep.get(1));
        GameManager.Instance.sonMaster.JoueBruitage((int)Utils.BruitageName.Jingle, false);
        displayNextStep();
    }

    private void DisplayRemoveItem(Step giveStep)
    {
        inventaire.Remove(giveStep.get(1));
        displayNextStep();
    }





}
