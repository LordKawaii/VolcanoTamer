using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolcanoController : MonoBehaviour {

	public List<GameObject> villagers;
	public Color lerpedColor = Color.green;

	float eruptionProgress = 0.5f; // progress towards eruption 0 to 1
	float eruptionRate = 0.002f; // rate eruption increase over time
	float villagerAppeasementRate = 0.001f; // rate that each villager brings down eruption

	// Use this for initialization
	void Start ()
	{
		villagers = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Renderer rend = GetComponent<Renderer>();

		eruptionProgress += eruptionRate;
		eruptionProgress -= villagers.Count * villagerAppeasementRate;
		if (eruptionProgress < 0)
		{
			eruptionProgress = 0.0f;
			Debug.Log("Safe");
		}

		if (eruptionProgress >= 1.0f)
		{
			eruptionProgress = 1.0f;
			Erupt();
		}
		rend.material.color = Color.Lerp(Color.green, Color.red, eruptionProgress);
	}

	void Erupt()
	{
		Debug.Log("Eruption!");

		// Kill All villagers at volcano
		for (int n = 0; n < villagers.Count; n++)
		{
			VillagerCon villager = villagers[n].GetComponent<VillagerCon>();
			villager.Kill();
			villagers.RemoveAt(n);
		}
	}


	public void AddVillager(GameObject villager)
	{
		villagers.Add(villager);
	}
}
