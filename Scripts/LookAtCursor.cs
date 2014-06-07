﻿using UnityEngine;
using System.Collections;

public class LookAtCursor : MonoBehaviour {
	public Transform zSource;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 m = Input.mousePosition;
		Vector3 v = Camera.main.ScreenToWorldPoint (new Vector3(m.x, m.y, 10));
		v.y = 0;
		transform.LookAt (v);
	}
}
