using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolcanoController : MonoBehaviour {

	public List<GameObject> villagers;

	// Use this for initialization
	void Start ()
	{
		villagers = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void AddVillager(GameObject villager)
	{
		villagers.Add(villager);
	}
}
