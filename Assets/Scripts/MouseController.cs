using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
	public Villager villager;
	public GameObject volcano;
	public GameObject village;


	// Use this for initialization
	void Start ()
	{
		
		village = GameObject.Find("Village");
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				Debug.Log(hit.transform.gameObject.♠sname);
				if (hit.transform.gameObject.tag == "Volcano")
				{
					Instantiate(villager, village.transform.position, Quaternion.identity);
					villager.SetVolcano(hit.transform.gameObject);
				}
			}
		}
	}
}
