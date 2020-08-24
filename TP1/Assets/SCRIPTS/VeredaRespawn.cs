using UnityEngine;
using System.Collections;

public class VeredaRespawn : MonoBehaviour 
{
	public string PlayerTag = "Player";

	// Use this for initialization
	void Start () 
	{
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == PlayerTag)
		{
			other.GetComponent<Respawn>().Respawnear();
		}	
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.tag == PlayerTag)
		{
			collision.gameObject.GetComponent<Respawn>().Respawnear();
		}
	}
	
}
