using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWall : MonoBehaviour {
    //tốc độ di chuyển của wall , ground
    public float speed = 30f;
    public float speed2 = 1f;
    public float speed3 = 1f;
    public float speed4 = 1f;
    public float speed5 = 1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //cho di chuyển 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        CountCoin.instance.MS += Time.deltaTime;
        if (Mathf.RoundToInt(CountCoin.instance.MS) >= 1010)
        {
            //cho di chuyển 
            transform.Translate(Vector3.left * speed2 * Time.deltaTime);
        }
        if (Mathf.RoundToInt(CountCoin.instance.MS) >= 1020)
        {
            //cho di chuyển 
            transform.Translate(Vector3.left * speed3 * Time.deltaTime);
        }
        if (Mathf.RoundToInt(CountCoin.instance.MS) >= 1030)
        {
            //cho di chuyển 
            transform.Translate(Vector3.left * speed4 * Time.deltaTime);
        }
        if (Mathf.RoundToInt(CountCoin.instance.MS) >= 1040)
        {
            //cho di chuyển 
            transform.Translate(Vector3.left * speed5 * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
