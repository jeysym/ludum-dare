﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {

	private Rigidbody2D rb;

    public int goldBarCount = 0;

    public float goldenBarSlowdown; 
	public float hSpeed;
	public float vSpeed;

    private bool xWasDown = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		float hAxis = Input.GetAxis("Horizontal");
		bool spaceDown = Input.GetKey(KeyCode.Space);
        bool xDown = Input.GetKey(KeyCode.X);

        float maxVForce = vSpeed + (1 - goldenBarSlowdown) * (float)goldBarCount;
        float maxHForce = hSpeed * hAxis;

		if (spaceDown)
		{
			rb.AddForce(new Vector2(0.0f, 1.0f) * maxVForce);
		}
		rb.AddForce(new Vector2(1.0f, 0.0f) * maxHForce);

        if (xDown && xWasDown == false)
        {
            xWasDown = true;
            if (goldBarCount > 0)
                goldBarCount--;
        }
        
        if (xDown == false)
            xWasDown = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoldenBar"))
        {
            other.gameObject.SetActive(false);
            goldBarCount++;
        }
    }
}