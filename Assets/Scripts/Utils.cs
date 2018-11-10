using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {
    public enum StepType
    {
        Description,
        Dialogue,
        Choix,
        Animation,
        Bruitage,
        Musique,
        Salle,
        Decor,
        Next,
        Condition,
        ChangeValeur,
        ChangeZone,
        ChangeInteraction,

    }
    public static StepType stringToEnum(string s)
    {
        StepType res;
        s = s.ToLower();
        switch (s)
        {
            case ("desc"):
                res = StepType.Description;
                break;
            case ("dial"):
                res = StepType.Dialogue;
                break;
            case ("choi"):
                res = StepType.Choix;
                break;
            case ("anim"):
                res = StepType.Animation;
                break;
            case ("brui"):
                res = StepType.Bruitage;
                break;
            case ("musi"):
                res = StepType.Musique;
                break;
            case ("sall"):
                res = StepType.Salle;
                break;
            case ("deco"):
                res = StepType.Decor;
                break;
            case ("path"):
                res = StepType.Next;
                break;
            case ("cond"):
                res = StepType.Condition;
                break;
            case ("valu"):
                res = StepType.ChangeValeur;
                break;
            case ("zone"):
                res = StepType.ChangeZone;
                break;
            case ("intr"):
                res = StepType.ChangeInteraction;
                break;
            default :
                res = StepType.Description;
                Debug.LogError("CustomError : Not a StepType : " + s);
                break;
        }
        return res;
    } 
}
