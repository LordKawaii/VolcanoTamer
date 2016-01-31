using UnityEngine;
using System.Collections;

public class VillagerCon : MonoBehaviour {

    public GameObject volcano = null;
    public GameObject village = null;
    float speed = 5.0f; // move speed
    bool isDead = false;
    bool hasHitVolcano = false;

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

        if (Vector3.Distance(volcano.transform.position, transform.position) > 3f)
        {
            Debug.Log("Speed: " + speed);
            speed = 5f;
            if (hasHitVolcano)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
            }

            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0);
            {
                Debug.Log("Im moving to fast");
            }
        }
       
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Volcano")
		{
			VolcanoController volcano = col.gameObject.GetComponent<VolcanoController>();
			speed = 0; // stop moving when we get to volcano
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0);
			volcano.AddVillager(gameObject);
            hasHitVolcano = true;
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
