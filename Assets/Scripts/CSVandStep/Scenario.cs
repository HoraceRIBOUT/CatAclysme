using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {


    public string startFile;

    [Header("RoomMode")]
    public List<Room> rooms = new List<Room>();
    //Instanciate each one, by vague probably, or at start


    [Header("CSV reading")]
    public bool readingCSV = false;
    public bool waitingForClick = false;

    public string pathOfNextCSV = "";
    public TextAsset nextCSVToRead;
    public List<Step> currentStepList = new List<Step>();
    public int currentPos = 0;

    




    // Use this for initialization
    void Start () {
        if (!GameManager.Instance._FEBUG_dont_start_with_startCVS)
        {
            if(pathOfNextCSV == "")
                pathOfNextCSV = startFile;
            TreatCSV();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (waitingForClick)
        {
            waitingForClick = false;
            if (Input.GetMouseButtonDown(0))
            {
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

    public void ExecutePath(string returningValue)
    {
        pathOfNextCSV = returningValue;
        TreatCSV();
    }

    private void DisplayNext(Step giveStep)
    {
        pathOfNextCSV = giveStep.get(1);
        TreatCSV();
    }


    private void DisplayAnimation(Step giveStep)
    {

    }

    private void DisplayBruitage(Step giveStep)
    {

    }

    private void DisplayMusique(Step giveStep)
    {

    }

    private void DisplaySalle(Step giveStep)
    {

    }

    private void DisplayDecor(Step giveStep)
    {

    }

    private void DislayCondition(Step giveStep)
    {

    }
    private void DisplayValeur(Step giveStep)
    {

    }
    private void DisplayZone(Step giveStep)
    {

    }

    private void DisplayInteraction(Step giveStep)
    {

    }





}
