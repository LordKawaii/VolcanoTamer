﻿using UnityEngine;
using System.Collections;

public class VillagerCon : MonoBehaviour {

    public GameObject volcano = null;
    public GameObject village = null;
    float speed = 5.0f; // move speed

    // Use this for initialization
    void Start()
    {
        village = GameObject.Find("Village");
    }

    // Update is called once per frame
    void Update()
    {
        if (volcano)
        {
            transform.position = Vector3.MoveTowards(transform.position, volcano.transform.position, speed * Time.deltaTime);
        }
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Volcano")
		{
			VolcanoController volcano = col.gameObject.GetComponent< VolcanoController >();
			speed = 0; // stop moving when we get to volcano
			volcano.AddVillager(gameObject);
		}
	}

	public void SetVolcano(GameObject targetObject)
    {
        volcano = targetObject;
    }
}
