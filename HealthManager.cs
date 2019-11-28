using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;

    public static int playerHealth;

    private LevelManager levelManager;

    public bool isDead;

    // Use this for initialization
    void Start ()
    {
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (playerHealth <= 0 && !isDead)
        {
            levelManager.RespawnPlayer();
            isDead = true;
        }
	}

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }

}
