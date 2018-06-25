using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender_ : MonoBehaviour {

	//line renderer effect
    private LineRenderer Effect;
    //all the points in the line
	public Vector3[] transforms;

    //base time
    [SerializeField]
    private float linespeed = 0.01f;
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
    //counter
    private int counter;
	// Use this for initialization
	void Start () {
		currentPoint = 0;
        Effect = GetComponent<LineRenderer>();
        Effect.SetPosition(0, transform.position);
        pointNumber = transforms.Length;
		currentLinePos = transform.position;
        currentOriginPos = transform.position;
        currentDesPos = transforms[0];
        currentDir = Vector3.Normalize(currentDesPos - currentOriginPos);
        counter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPoint < pointNumber)
        {
            if (Vector3.Distance(currentLinePos, currentDesPos) >= 0.05f)
            {
                currentLinePos = counter*currentDir * linespeed + currentOriginPos;
                Effect.SetPosition(currentPoint + 1, currentLinePos);
                counter++;
            }
			else
            {
                if ((currentPoint + 1) < pointNumber)
                {
                    counter = 0;
					currentOriginPos = transforms[currentPoint];
                    currentPoint++;
                    Effect.positionCount++;//当需要增加一个节点当时候再增加，不然未初始化当节点位置都是初始位置，视觉效果奇怪
                    Effect.SetPosition(currentPoint + 1, currentLinePos);
                    currentDesPos = transforms[currentPoint];
					Debug.Log("line2"+currentDesPos+" "+currentLinePos);
                    currentDir = Vector3.Normalize(currentDesPos - currentOriginPos);
                    //Debug.Log("currentDir" + currentDir);
                }
            }
		}    
      }
	void test()
	{
		for (int i = 0; i < 100; i++)
        {
            currentLinePos = Vector3.Lerp(currentOriginPos, currentDesPos, i * 0.01f);
            Effect.SetPosition(currentPoint + 1, currentLinePos);
        }
	}

	}
