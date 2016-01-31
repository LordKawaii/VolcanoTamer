using UnityEngine;
using System.Collections;

public class VillageController : MonoBehaviour {


    VillageUIContoller uiController;
    int resources = 0;

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
        if (Time.time >= spawnTimer)
        {
            spawnTimer = Time.time + spawnTimerLength;
            resources++;
            uiController.SetResources(resources);
        }
    }
}
