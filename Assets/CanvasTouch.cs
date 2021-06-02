using System.Collections;
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
                    currLine.positionCount++;
                    currLine.SetPosition(currLine.positionCount - 1, fingerPos);                   
                }
                
                if (Vector3.Distance(currLine.GetPosition(currLine.positionCount - 2), fingerPos) > 0.001f)
                    GetComponent<AudioSource>().UnPause();
                else
                    GetComponent<AudioSource>().Pause();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        touchingCanvas = true;
        if (finger == null)
        {
            finger = other.transform.gameObject;
        }
            GetComponent<AudioSource>().Play();
            GameObject newLineObject = new GameObject();
            newLineObject.transform.parent = this.gameObject.transform;
            currLine = newLineObject.gameObject.AddComponent<LineRenderer>();
            currLine.startWidth = 0.01f;
            currLine.endWidth = 0.01f;

            //Updates the line start position to not be directly at (0,0,0) but a the first fingertip position.
            currLine.SetPosition(0, finger.transform.position);
            currLine.SetPosition(1, finger.transform.position);
            return;
        
    }

    private void OnTriggerExit(Collider other)
    {
        touchingCanvas = false;
        currLine = null;
        GetComponent<AudioSource>().Stop();
    }
}
