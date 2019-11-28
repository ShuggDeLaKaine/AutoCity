using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour {
    
	public float lifeLeft;
 

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeLeft -= Time.deltaTime;

		if(lifeLeft < 0)
		{
			Destroy(gameObject);
		}
	}
}