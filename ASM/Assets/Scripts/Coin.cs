using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public SoundManager audioSource;
    public float speed = 30f;
    // Use this for initialization
    void Start () {
        audioSource = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //cho di chuyển 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Playsound("coins");
            if (CountCoin.instance != null)
            {
                CountCoin.instance.Total_coin += 1;
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
