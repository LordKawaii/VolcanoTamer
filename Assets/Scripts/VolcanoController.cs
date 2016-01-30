using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolcanoController : MonoBehaviour {

	public List<VillagerCon> villagers;

	// Use this for initialization
	void Start ()
	{
		villagers = new List<VillagerCon>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void AddVillager(VillagerCon villager)
	{
		villagers.Add(villager);
	}
}
