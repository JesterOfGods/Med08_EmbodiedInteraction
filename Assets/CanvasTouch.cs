using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTouch : MonoBehaviour
{
    public GameObject brush;
    public float ZfightingFix = 0.1f;
    //public GameObject canvas;
    public float size = 0.005f;
    private bool touchingCanvas;
    private GameObject finger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (finger != null)
        {
            if (touchingCanvas)
            {
                var go = Instantiate(brush, finger.transform.position + this.transform.forward * -1 * ZfightingFix, Quaternion.FromToRotation(Vector3.up, this.transform.forward * -1), this.transform);
                go.transform.localScale = Vector3.one * size;
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
    }

    private void OnTriggerExit(Collider other)
    {
        touchingCanvas = false;
    }
}
