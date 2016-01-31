using UnityEngine;
using System.Collections;

public class VillagerCon : MonoBehaviour {

    public GameObject volcano = null;
    public GameObject village = null;
    float speed = 5.0f; // move speed
    bool isDead = false;

    public float fDeathDelay = 1;
    float deathTimer = 0;

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

        if (isDead && Time.time >= deathTimer)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(volcano.transform.position, transform.position) > 1)
        {

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

	public void Kill()
	{
        //Renderer rend = GetComponent<Renderer>();
        //rend.material.color = Color.red;
        // a second later delete and remove from volcano

        //Remove Villager and play partical effects
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        isDead = true;
        deathTimer = Time.time + fDeathDelay;
    }

}
