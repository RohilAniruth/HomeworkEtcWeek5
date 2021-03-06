﻿using UnityEngine;
using System.Collections;

public class backAndForth : MonoBehaviour {
	public Transform FishPath1;
	public Transform FishPath2;

	public float percent = 0;

	public float numberOfSeconds = 3;
	public float direction = -1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// set position for the cube as an interpolation
		transform.position = Vector3.Lerp(FishPath1.position, FishPath2.position, percent);
		transform.rotation = Quaternion.Slerp (FishPath1.rotation, FishPath2.rotation, percent);
		// for lerping a float: Mathf.Lerp ();

		//percent = percent + 1/60f;
		// Time.deltaTime is the amount of change between this frame and the last one
		percent += Time.deltaTime / numberOfSeconds * direction;
		if (percent > 1) {
			direction = -1;
		}
		if (percent < 0) {
			direction = 1;
		}

		GetComponent<Renderer> ().material.color = Color.Lerp (Color.red, Color.blue, percent);
	}
}
