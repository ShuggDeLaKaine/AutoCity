using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    //adjustable enemy health
    public int enemyHealth;

    public GameObject enemyDeathFX;

    //add prefab for the DeathFX and remains
    //public GameObject deathFX;

    void Start()
    {

    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            //when at health 0, instantiate the death FX and destroy the enemy object in scene
            Instantiate(enemyDeathFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
        GetComponent<AudioSource>().Play();
    }
    
}
