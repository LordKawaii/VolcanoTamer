using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
	public GameObject villager;
	public GameObject volcano;
	public GameObject village;

    VillageController villageCon;


	// Use this for initialization
	void Start ()
	{
        villageCon = GameObject.FindGameObjectWithTag("Village").GetComponent<VillageController>();
		village = GameObject.Find("Village");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetMouseButtonDown(0) && villageCon.GetResourceCount() > 0)
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.transform.gameObject.tag == "Volcano" )
				{
                    villageCon.DeclementeResourceCount();
                    Debug.Log(hit.transform.gameObject.name);

                    VillagerCon villagerCon;
                    GameObject tempVillager;
                    tempVillager = Instantiate(villager, village.transform.position, Quaternion.identity) as GameObject;
                    villagerCon = tempVillager.GetComponent<VillagerCon>();
                    villagerCon.SetVolcano(hit.transform.gameObject);

                    
				}
			}
		}
	}
}
