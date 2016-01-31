using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text gameOverText;

    List<VolcanoController> volcanos;
    bool hasLost = false;

	// Use this for initialization
	void Start () {
        volcanos = new List<VolcanoController>();
        foreach (GameObject volcano in GameObject.FindGameObjectsWithTag("Volcano"))
        {
            volcanos.Add(volcano.GetComponent<VolcanoController>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckForLose())
        { 
            hasLost = true;
            gameOverText.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && hasLost)
            Application.LoadLevel(0);

    }

    bool CheckForLose()
    {
        int numVolcanosTamedToLose = volcanos.Count;
        int numVolcanosTamed = 0;

        foreach (VolcanoController volcano in volcanos)
        {
            if (volcano.CheckForEruption())
            {
                numVolcanosTamed++;
            }
        }

        if (numVolcanosTamed == numVolcanosTamedToLose)
            return true;

        return false;
    }
}
