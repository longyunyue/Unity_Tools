using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionLerp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion targetQuaternion = Quaternion.LookRotation(new Vector3(1f, 0f, 1f)-transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime);
	}
}
