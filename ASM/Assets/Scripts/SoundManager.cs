using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip coins, jump, destroy;
    public AudioSource adisrc;
    // Use this for initialization
    void Start () {
        coins = Resources.Load<AudioClip>("coin");
        jump = Resources.Load<AudioClip>("jump");
        destroy = Resources.Load<AudioClip>("death");
        adisrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;

            case "jump":
                adisrc.clip = jump;
                adisrc.PlayOneShot(jump, 1f);
                break;

        }
    }
    }
