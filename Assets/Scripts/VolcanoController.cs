using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolcanoController : MonoBehaviour {

	public List<GameObject> villagers;
	public Color lerpedColor = Color.green;

	float eruptionProgress = 0.5f; // progress towards eruption 0 to 1
	float eruptionRate = 0.009f; // rate eruption increase over time
	float villagerAppeasementRate = 0.003f; // rate that each villager brings down eruption

	public float eruptionTimerLength = 0.1f;
	float eruptionTimer;
    bool hasErupted = false;
	bool isTamed = false;
    public float eruptionResetTimerLength = .5f;
    float eruptionResetTimer;

	// Use this for initialization
	void Start ()
	{
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
		eruptionTimer = Time.time + eruptionTimerLength;

		villagers = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Renderer rend = GetComponent<Renderer>();

        if (hasErupted && Time.time >= eruptionResetTimer)
        {
            eruptionProgress = .75f;
            hasErupted = false;
        }

		if (Time.time >= eruptionTimer && !hasErupted)
		{
			eruptionTimer = Time.time + eruptionTimerLength;
			
			eruptionProgress += eruptionRate;
			eruptionProgress -= villagers.Count * villagerAppeasementRate;
			if (eruptionProgress < 0)
			{
				eruptionProgress = 0.0f;
				isTamed = true;
			}

			if (eruptionProgress >= 1.0f)
			{
				Erupt();
			}
			rend.material.color = Color.Lerp(Color.green, Color.red, eruptionProgress);
		}

        setSoundLevel();
    }

	void Erupt()
	{
		Debug.Log("Eruption!");
        hasErupted = true;
        eruptionResetTimer = Time.time + eruptionResetTimerLength;

        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        gameObject.GetComponentInChildren<ParticleSystem>().Play();

        // Kill All villagers at volcano
        for (int n = 0; n < villagers.Count; n++)
		{
			VillagerCon villager = villagers[n].GetComponent<VillagerCon>();
			villager.Kill();
			villagers.RemoveAt(n);
		}
	}

    void setSoundLevel()
    {
        gameObject.GetComponent<AudioSource>().volume = eruptionProgress;
    }


	public void AddVillager(GameObject villager)
	{
        if (!villagers.Contains(villager))
        { 
		    villagers.Add(villager);
        }
    }

    public bool CheckForEruption()
    {
        return hasErupted;
    }

	public bool CheckForTamed()
	{
		return isTamed;
	}
}
