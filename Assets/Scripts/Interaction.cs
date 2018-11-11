using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction {

    public string id;
    public bool item;
    public EnumUtils.textAvailable pathToFollow;

    public bool active = true;
}
