using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender_v5 : MonoBehaviour
{
	//line renderer effect
	private LineRenderer Effect;
	//all the points in the line
	public Vector3[] transforms;
	//every single time
	[Range(0.5f,2f)]
	public float singletime;
	//current point 
	private int currentPoint;
	//numbers of point
	private int pointNumber;
	//current origin point position
	private Vector3 currentOriginPos;
	//current destination point position
	private Vector3 currentDesPos;
	//current line position
	private Vector3 currentLinePos;
	//current Direction
	private Vector3 currentDir;
	private float time;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(DrawLines(transforms, singletime));
	}

	IEnumerator DrawLines(Vector3[] pointslist, float drawtime)
	{
		Effect = GetComponent<LineRenderer>();
		Effect.positionCount = 1;
		currentPoint = 0;
		Effect.SetPosition(currentPoint, transform.position);
		currentDesPos = transform.position;
		for (int i = 0; i < pointslist.Length; i++)
        {
			time = 0f;
            currentOriginPos = currentDesPos;
            currentDesPos = pointslist[i];
			currentDir = Vector3.Normalize(currentDesPos - currentOriginPos);
			Effect.positionCount++;
			while(time<=drawtime)
			{
				time += Time.deltaTime;
				Effect.SetPosition(i+1, Vector3.Lerp(currentOriginPos, currentDesPos, time / drawtime));
				yield return true;
			}

        }
	}
}

