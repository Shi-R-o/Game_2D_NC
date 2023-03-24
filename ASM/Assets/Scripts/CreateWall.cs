using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour {

    //các khối vật cản
    public GameObject wallBasic;
    public GameObject coindichuyen;
    //GameObject vừa tạo
    public GameObject obvitri;
    public GameObject vitricoin;
    // Use this for initialization
    void Start()
    {
        //chạy Creat();
        StartCoroutine(Creat());
        StartCoroutine(Creact());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Creat()
    {
        //đợi 3s

        yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        //lấy vị trí để sinh ra
        Vector3 temp = obvitri.transform.position;
        //randum chiều cao
        temp.y = Random.Range(-6f, -2.8f);
        //Instantiate sinh ra wallbasic, temp vector3 
        Instantiate(wallBasic, temp, Quaternion.identity);


        StartCoroutine(Creat());
    }
    IEnumerator Creact()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        //lấy vị trí để sinh ra
        Vector3 temp = vitricoin.transform.position;
        //randum chiều cao
        temp.y = Random.Range(0.2f,1.5f);
        //Instantiate sinh ra wallbasic, temp vector3 
        Instantiate(coindichuyen, temp, Quaternion.identity);
        StartCoroutine(Creact());
    }
}
