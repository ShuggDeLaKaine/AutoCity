using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtPlayer : MonoBehaviour {

    //adjustable range for the enemy to fire at the player
    public float playerRange;

    //grab the prefab for the projectile
    public GameObject enemyProjectile;

    //so can identify where the player in the scene is
    public PlayerController player;

    //a transform point to instantiate and 'launch' the projectile from
    public Transform launchPoint;

    //counter so there is delay between firing
    public float delayBetweenFiring;
    private float fireCounter;

    // Use this for initialization
    void Start()
    {
        //locating the player in scene
        player = FindObjectOfType<PlayerController>();

        //setting the fire countdown counter to the delay between firing
        fireCounter = delayBetweenFiring;
    }

    // Update is called once per frame
    void Update()
    {
        //debug to draw a line which represents the enemies range, gives a visual representation on the scene, reduce need for trail and error
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        //start countdown until next possible shot
        fireCounter -= Time.deltaTime;

        //localScale = if it's 1 facing right, less than 0, it's facing Left
        //player.transform = testing that the player is on the righthand side of the enemy
        //player.transform & playerRange = that the player is also in range
        //fireCounter = checking that the counter is < 0, so the enemy can shot 
        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && fireCounter < 0)
        {
            //instantiate projectile at the launch point, launch point will be an empty child of the enemy prefab
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            //reset the shot counter to the wait time between firing for that enemy.
            fireCounter = delayBetweenFiring;
        }

        //same as above but testing for the left hand side.
        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && fireCounter < 0)
        {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            fireCounter = delayBetweenFiring;
        }
    }
}
