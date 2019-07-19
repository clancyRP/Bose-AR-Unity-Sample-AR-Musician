using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTile : MonoBehaviour {

    AudioSource audioSource;

	
	void Start () {
        // Modulate pitch based on Y position
        float positionY = transform.position.y;
        positionY += 0.54f;
        audioSource = GetComponent<AudioSource>();

        audioSource.pitch = 1f + positionY * 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
        // Change to default color
        if (audioSource.isPlaying == false){
            gameObject.GetComponent<Renderer>().material.color = new Color(1f,1f,1f,0.8f);
        }

	}

    public void PlayTile(){
        // Change to green color
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

    }
}
