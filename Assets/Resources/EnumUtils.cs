using UnityEngine;
using System.Collections;

public class EnumUtils : MonoBehaviour {
 
 public enum textAvailable { 
      Test01,
      WholeWithPose,
      Ruelle_yeah,
      FirstWhole,
      nop,
      yeah,
      Chambre_Grattoir_fouiller,
      Chambre_Grattoir_nop,
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
