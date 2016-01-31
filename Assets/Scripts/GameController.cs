using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text gameOverText;

    List<VolcanoController> volcanos;
    bool hasLost = false;
	bool hasWon = false;

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

			if (CheckForWin())
			{
				hasWon = true;
			gameOverText.text = "You've won!\nPress R to restart!";
				gameOverText.enabled = true;
			}

		if (Input.GetKeyDown(KeyCode.R) && (hasLost || hasWon))
            Application.LoadLevel(0);

    }

    bool CheckForLose()
    {
        int numVolcanosEruptedToLose = volcanos.Count;
        int numVolcanosErupted = 0;

        foreach (VolcanoController volcano in volcanos)
        {
            if (volcano.CheckForEruption())
            {
					numVolcanosErupted++;
            }
        }

        if (numVolcanosErupted == numVolcanosEruptedToLose)
            return true;

        return false;
    }

	bool CheckForWin()
	{
		int numVolcanosTamedToWin = volcanos.Count;
		int numVolcanosTamed = 0;

		foreach (VolcanoController volcano in volcanos)
		{
			if (volcano.CheckForTamed())
			{
				numVolcanosTamed++;
			}
		}

		if (numVolcanosTamed == numVolcanosTamedToWin)
			return true;

		return false;
	}

	public bool IsGameOver()
	{
		return hasWon || hasLost;
	}
}
