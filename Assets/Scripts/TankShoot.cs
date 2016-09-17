﻿using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour {

    public GameObject shootPos;
    public GameObject bullet;
    float shootTimer = 0.2f;
    public float timer = 0f;
    //public KeyCode keyCode = KeyCode.Space;
    public KeyCode keyCode;
    public float bulletSpeed = 50f;
    float curTime = 0f;
    bool keyHold = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyCode))
        {
            keyHold = true;
        }
        //Debug.Log(timer);

        if (Input.GetKeyUp(keyCode))
        {
           //Debug.Log(timer);
            if (timer > shootTimer)
            {
                Debug.Log("Shoot");
                GameObject Bullet = Instantiate(bullet, shootPos.transform.position, Quaternion.identity) as GameObject;
                // transform.up is green axis
                Bullet.GetComponent<Rigidbody2D>().velocity = shootPos.transform.up * bulletSpeed;
            }
            else
            {
                Debug.Log("Cannot shoot because time is not enough. " + timer);
            }
            timer = 0;
            keyHold = false;
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (keyHold)
            {
                timer += Time.deltaTime;
            }
            yield return null;
        }
    }
}
