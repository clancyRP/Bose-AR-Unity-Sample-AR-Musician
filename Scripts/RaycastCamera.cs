using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera : MonoBehaviour {
    
	
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            // Plays sound 
            hit.transform.gameObject.GetComponent<AudioTile>().PlayTile();
        }
	}
}
