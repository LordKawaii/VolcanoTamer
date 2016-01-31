using UnityEngine;
using System.Collections;

public class VillageController : MonoBehaviour {


    VillageUIContoller uiController;
    int resources = 0;
    public int maxResources = 4;

    public float spawnTimerLength = 1;
    float spawnTimer;

    // Use this for initialization
    void Start()
    {
        spawnTimer = Time.time + spawnTimerLength;

        uiController = gameObject.GetComponent<VillageUIContoller>();
        uiController.SetResources(resources);
    }

    void Update()
    {
        if (Time.time >= spawnTimer && resources < maxResources)
        {
            spawnTimer = Time.time + spawnTimerLength;
				resources++;
        }
        uiController.SetResources(resources);
    }

    public int GetResourceCount()
    {
        return resources;
    }

    public void DeclementeResourceCount()
    {
		  // restart timer if we were at max resources
        if(resources == maxResources)
           spawnTimer = Time.time + spawnTimerLength;
        resources--;
    }
}
