using UnityEngine;
using System.Collections;

public class EnumUtils : MonoBehaviour {
 
 public enum textAvailable { 
      BZK_Dial,
      BZK_Item_Hache,
      BZK_NoHache,
      BZK_PostHache,
      Chaladin_Lumière,
      Chaladin_noClue,
      Chatmallow_Dial,
      Chatmallow_Item_Recette,
      Chatmallow_noRecette,
      Chatmallow_PostRecette,
      Gouttiere_Dial,
      Gouttiere_Item_Snack,
      Gouttiere_NoSnack,
      Gouttiere_PostSnack,
      Nekonomicon_Interact,
      Neko_Dial,
      Neko_Item_Nekonomicon,
      Neko_noNekonomicon,
      Neko_PostNekonomicon,
      NinChat_Dial,
      NinChat_Item_Herbe,
      NinChat_NoHerbe,
      NinChat_PostHerbe,
      PickUp_Hache,
      PickUp_Item_Hache,
      PickUp_Item_Nekonomicon,
      PickUp_Item_Recette,
      PickUp_Item_Snack,
      PickUp_Item_Tabouret,
      PickUp_Nekonomicon,
      Porte_BZKHelp,
      Porte_Chambre_Interact,
      Porte_Couloir_Interact,
      Porte_Couloir_Item_Clé,
      Porte_Etage,
      Porte_GrdSalle,
      Porte_Help,
      Porte_Interact,
      Porte_Locked,
      Porte_NekoHelp,
      Porte_NoHelp,
      Porte_Ruelle,
      Porte_UnLocked,
      Intro,
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
