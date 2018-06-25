using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender_v3 : MonoBehaviour
{

    //line renderer effect
    private LineRenderer Effect;
    //all the points in the line
    public Vector3[] transforms;

    //base time
	[Range(0.01f,0.05f)]
    public float linespeed;
	private int countMax;
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
	private bool isdone=false;
    // Use this for initialization
    void Start()
    {
		countMax = (int)(1f / linespeed);
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
    void Update()
    {
        if (currentPoint < pointNumber)
        {
			if (counter<=countMax)
            {
				currentLinePos = Vector3.Lerp(currentOriginPos, currentDesPos, counter * linespeed);
				Effect.SetPosition(currentPoint + 1, currentLinePos);
				counter++;
            }
            else
            {
                if ((currentPoint + 1) < pointNumber)
                {
                    counter = 1;
                    currentOriginPos = transforms[currentPoint];
                    currentPoint++;
                    Effect.positionCount++;//当需要增加一个节点当时候再增加，不然未初始化当节点位置都是初始位置，视觉效果奇怪
                    Effect.SetPosition(currentPoint + 1, currentLinePos);
                    currentDesPos = transforms[currentPoint];
                    Debug.Log("line2" + currentDesPos + " " + currentLinePos);
                    currentDir = Vector3.Normalize(currentDesPos - currentOriginPos);
                    //Debug.Log("currentDir" + currentDir);
                }
            }
        }
    }
    
}
