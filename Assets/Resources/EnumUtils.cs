using UnityEngine;
using System.Collections;

public class EnumUtils : MonoBehaviour {
 
 public enum textAvailable { 
      Intro,
      Chatladin_noClue,
      Chatmallow_Dial,
      Chatmallow_Item_Recette,
      Chatmallow_noRecette,
      Chatmallow_PostRecette,
      PickUp_Item_Recette,
      Chatmallow_NoRecette,
      Porte_Etage,
      Porte_GrdSalle,
 } 
 
 
     // Update is called once per frame
     public static string ChangeToPath (textAvailable enumGiven) {
       string res =  enumGiven.ToString().Replace("_", "/");
       return res+".txt"; 
     }
 
     public static textAvailable ChangeToEnum(string s)
     {
     return (textAvailable)System.Enum.Parse(typeof(textAvailable), s);
     }
}
