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
    public bool readingCSV = false;
    public bool waitingForClick = false;

    public EnumUtils.textAvailable pathOfNextCSV;
    public TextAsset nextCSVToRead;
    public List<Step> currentStepList = new List<Step>();
    public int currentPos = 0;

    [Header("Progression")]
    public Dictionary<string, bool> dicoBool = new Dictionary<string, bool>();




    // Use this for initialization
    void Start () {
        if (!GameManager.Instance._FEBUG_dont_start_with_startCVS)
        {
            if((int)pathOfNextCSV == 0)
                pathOfNextCSV = startFile;
            TreatCSV();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (waitingForClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                waitingForClick = false;
                displayNextStep();
            }
        }
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


    private void DisplayAnimation(Step giveStep)
    {

        displayNextStep();
    }

    private void DisplayBruitage(Step giveStep)
    {

        displayNextStep();
    }

    private void DisplayMusique(Step giveStep)
    {
        int indexOfMusique = (int)Utils.stringToMusiqueName(giveStep.get(1));
        GameManager.Instance.sonMaster.ChangeMusique(indexOfMusique);
        displayNextStep();
    }

    private void DisplaySalle(Step giveStep)
    {

        displayNextStep();
    }

    private void DisplayDecor(Step giveStep)
    {

        displayNextStep();
    }

    private void DisplayValeur(Step giveStep)
    {
        string value = giveStep.get(1);
        bool key = giveStep.get(2) == "TRUE";
        if (dicoBool.ContainsKey(value))
            dicoBool[value] = key;
        else
            dicoBool.Add(value, key);
        displayNextStep();
    }

    private void DislayCondition(Step giveStep)
    {
        string index = giveStep.get(1);
        bool res;
        /*res = */dicoBool.TryGetValue(index, out res);
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
        //TO DO
        displayNextStep();
    }

    private void DisplayInteraction(Step giveStep)
    {
        //.???
        displayNextStep();
    }





}
