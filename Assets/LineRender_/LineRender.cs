using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{

    //line renderer effect
    private LineRenderer Effect;
    //all the points in the line
    public Transform[] transforms;
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
    void Start()
    {
        currentPoint = 0;
        Effect = GetComponent<LineRenderer>();
        Effect.SetPosition(0,transforms[0].position);
        pointNumber = transforms.Length;
        currentLinePos = transforms[0].position;
        currentOriginPos = transforms[0].position;
        currentDesPos = transforms[1].position;
        currentDir = Vector3.Normalize(currentDesPos - currentOriginPos);
        counter = 1;
        Debug.Log(pointNumber);
        Debug.Log(currentDir);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("currentPoint: "+ currentPoint + currentLinePos);
        if (currentPoint < pointNumber)
        {
            if (Vector3.Distance(currentLinePos, currentDesPos) >= 0.01f)
            {
                currentLinePos = counter * currentDir * linespeed + currentOriginPos;
                Effect.SetPosition(currentPoint+1,currentLinePos);
                counter++;
            }
            else if((currentPoint + 1) < (pointNumber - 1))
            {
                counter = 0;
                currentPoint++;
                Effect.positionCount++;//当需要增加一个节点当时候再增加，不然未初始化当节点位置都是初始位置，视觉效果奇怪
                Effect.SetPosition(currentPoint + 1, currentLinePos);
                currentOriginPos = transforms[currentPoint].position;
                currentDesPos = transforms[currentPoint+1].position;
                currentDir = Vector3.Normalize(currentDesPos - currentOriginPos);
                Debug.Log("currentDir"+currentDir);
            }
            else{}
        }

    }


}
