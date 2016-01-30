using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolcanoController : MonoBehaviour {

	public List<Villager> villagers;

	// Use this for initialization
	void Start ()
	{
		villagers = new List<Villager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void AddVillager(Villager villager)
	{
		villagers.Add(villager);
	}
}
