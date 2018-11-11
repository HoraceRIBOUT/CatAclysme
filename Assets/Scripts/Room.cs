using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public List<Zone> zones = new List<Zone>();

    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        foreach (Zone z in GetComponentsInChildren<Zone>())
        {
            if (!zones.Contains(z))
            {
                Debug.LogError(z.name + " (id = "+z.id+") n'a pas été ajouté dans la Room :" + this.name);
            }
        }
#endif
    }
	
}
