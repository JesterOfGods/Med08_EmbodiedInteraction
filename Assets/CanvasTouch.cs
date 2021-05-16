﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTouch : MonoBehaviour
{
    public GameObject brush;
    public float ZfightingFix = 0.01f;
    //public GameObject canvas;
    public float size = 0.005f;
    private bool touchingCanvas;
    private GameObject finger;

    public Material lineMat;
    private LineRenderer currLine = null;
    private bool lineStartUpdated = false;

    // Update is called once per frame
    void Update()
    {
        if (finger != null)
        {
            if (touchingCanvas)
            {
                Vector3 fingerPos = finger.transform.position + this.transform.forward * -1 * ZfightingFix;

                if (currLine)
                {

                    //Updates the line start position to not be directly at (0,0,0) but a the first fingertip position.
                    if (!lineStartUpdated)
                    {
                        currLine.SetPosition(0, fingerPos);
                        currLine.SetPosition(1, fingerPos);
                        lineStartUpdated = true;
                        return;
                    }
                    currLine.positionCount++;
                    currLine.SetPosition(currLine.positionCount - 1, fingerPos);
                }

            }   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        touchingCanvas = true;
        if (finger == null)
        {
            finger = other.transform.gameObject;

            GameObject newLineObject = new GameObject();
            newLineObject.transform.parent = this.gameObject.transform;
            currLine = newLineObject.gameObject.AddComponent<LineRenderer>();
            currLine.startWidth = 0.01f;
            currLine.endWidth = 0.01f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        touchingCanvas = false;
        currLine = null;
        lineStartUpdated = false;
    }
}
