using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;

    public HealthManager healthManager;

    public GameObject playerDeathParticleFX;
    public GameObject respawnParticleFX;

    public float respawnDelay;


    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController>();

        healthManager = FindObjectOfType<HealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }
    

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(playerDeathParticleFX, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        //camera.isFollowing = false;
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        //camera.isFollowing = true;
        Instantiate(respawnParticleFX, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
