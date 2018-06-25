using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilMove : MonoBehaviour {
	public float speed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Vertical = Input.GetAxis("Vertical");
		float Horizontal = Input.GetAxis("Horizontal");

		transform.Translate(0f, speed * Vertical, -speed*Horizontal);
	}
}
