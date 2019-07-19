using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip introSound;
    private Transform[] soundTiles;
    private AudioClip[] sounds;


    public AudioSource loopSound;

    //Play loop sound after intro
    IEnumerator delayPlay(float time){
        yield return new WaitForSeconds(time);
        loopSound.Play();
    }

	void Start () {

        //Use length of the introSound to define when the loop should start playing
        StartCoroutine(delayPlay(introSound.length));

        // Get our collision tiles inside the sound sphere
        soundTiles = GameObject.Find("sound_sphere").transform.GetComponentsInChildren<Transform>();

        // Get all our sounds from Resources/Sounds
        sounds = Resources.LoadAll<AudioClip>("Sounds");

       
        foreach (AudioClip snd in sounds){
            //Naming convention of sounds is as follows - Column 1, Row 1 is c1r1_nameofsound
            string soundName = snd.name;
            string[] s = soundName.Split("_"[0]);

            char columnChar = s[0][1];
            char rowChar = s[0][3];

            //Convert char to string
            string col = columnChar + "";
            string r = rowChar + "";


            int column = 0;
            int row = 0;
            int.TryParse(col,out column);
            int.TryParse(r,out row);

            // Currently this places the same sound in each column, it is being modulated by pitch in the AudioTile script
            if (column * row != 0)
            {
                soundTiles[column * 4].GetComponent<AudioSource>().clip = snd;
                soundTiles[column * 4 - 1].GetComponent<AudioSource>().clip = snd;
                soundTiles[column * 4 - 2].GetComponent<AudioSource>().clip = snd;
                soundTiles[column * 4 - 3].GetComponent<AudioSource>().clip = snd;


            }


        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
