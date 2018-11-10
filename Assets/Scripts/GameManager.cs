using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    private void Awake()
    {
        if (GameManager.Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    [Header("Other part of the Manager")]
    public CSV_Reader csv_reader;
    public UI_Holder ui_holder;
    public Scenario scenario;


    
    
    // Use this for initialization
    void Start () {
        if (csv_reader == null)
            csv_reader = this.GetComponent<CSV_Reader>();
        if (ui_holder == null)
            ui_holder = this.GetComponent<UI_Holder>();//oula nope
        if (scenario == null)
            scenario = this.GetComponent<Scenario>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    

}
