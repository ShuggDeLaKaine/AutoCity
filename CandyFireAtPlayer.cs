using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyFireAtPlayer : MonoBehaviour
{

    //adjustable speed for projectile
    public float speed;

    //get the player controller script, can locate player in screen with this.
    public PlayerController player;

    //add prefab for explosion FX
    public GameObject impactEffect;

    public float rotationSpeed;

    //amount of damage this enemy can give to the player
    public int damageToGive;

    private Rigidbody2D myrigidbody2D;

    // Use this for initialization
    void Start()
    {
        //find the player in screen using the player controller script
        player = FindObjectOfType<PlayerController>();
        myrigidbody2D = GetComponent<Rigidbody2D>();

        //if the player is to the left of the enemy, this sets the speed to minus, so it goes left
        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(speed, myrigidbody2D.velocity.y);
        myrigidbody2D.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        //there will always be a player in the scene can can just use other.name == "Player"
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }
        */

        //attach the prefab for the explosion FX
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
