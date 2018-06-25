using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineRender_v4 : MonoBehaviour {
	//store the lines
	private ArrayList lines = new ArrayList();

	private bool lineCreated;
	private bool isSaved;
	//lines variables
	private GameObject curLine;
	private Vector3 curPosition;
	private int curPointNum=0;

	public GameObject linePrefab;
	public bool DrawLine;
	public bool Clear;
	public float pointGap;
	// Use this for initialization
	void Start () {
		//DrawLine = false;
		lineCreated = false;
		isSaved = true;
		pointGap = 0.5f;
		Clear = false;
	}
	
	// Update is called once per frame
	void Update () {
		getInput();
		drawLines();
		if (Clear)
			clearLines();

	}
	void drawLines()
	{
		if (DrawLine)
        {
            if (!lineCreated)
            {
                curLine = Instantiate(linePrefab, transform.position, transform.rotation);
                curLine.GetComponent<LineRenderer>().SetPosition(curPointNum, transform.position);
                curPosition = transform.position;
                curPointNum++;
				curLine.GetComponent<LineRenderer>().positionCount++;
				curLine.GetComponent<LineRenderer>().SetPosition(curPointNum, curPosition);
                lineCreated = true;
				isSaved = false;
            }
            else
            {
				curLine.GetComponent<LineRenderer>().SetPosition(curPointNum, transform.position);
                if (Vector3.Distance(transform.position, curPosition) >= pointGap)
                {
                    curLine.GetComponent<LineRenderer>().positionCount++;
                    curPosition = transform.position;
                    curPointNum++;
					curLine.GetComponent<LineRenderer>().SetPosition(curPointNum, curPosition);
                }
            }
        }
        else
        {
            if (!isSaved)
            {
				lines.Add(curLine);
				Debug.Log(lines.Count);
                isSaved = true;
				lineCreated = false;
				curPointNum = 0;
            }
        }
	}
    //clear all lines
	void clearLines()
	{
		if (lines.Count != 0)
		{
			foreach (GameObject line in lines)
				Destroy(line);
			Debug.Log("destroy!"+lines.Count);
			lines.Clear();
			Clear = false;
		}
		else
		{
			Debug.Log("list already cleared!");
			Clear = false;
		}
			
	}
	void getInput()
	{
		if (Input.GetKeyUp(KeyCode.A))
		{
			DrawLine = !DrawLine;
		}

		if (Input.GetKeyUp(KeyCode.B))
			Clear = true;
	}
		
}
