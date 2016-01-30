using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolcanoController : MonoBehaviour {

	public List<GameObject> villagers;
	public Color lerpedColor = Color.green;

	float eruptionProgress = 0.5f;

	// Use this for initialization
	void Start ()
	{
		villagers = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Renderer rend = GetComponent<Renderer>();

		eruptionProgress += 0.01f;
		eruptionProgress -= villagers.Count * 0.02f;
		if (eruptionProgress < 0)
		{
			eruptionProgress = 0.0f;
			Debug.Log("Safe");
		}

		if (eruptionProgress >= 1.0f)
		{
			eruptionProgress = 1.0f;
			//transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
			Debug.Log("Eruption!");
		}

		rend.material.color = Color.Lerp(Color.green, Color.red, eruptionProgress);

	}

	public void AddVillager(GameObject villager)
	{
		villagers.Add(villager);
	}
}
