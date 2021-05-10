using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PaintBrush2 : MonoBehaviour
{
    public GameObject brush;
    public float ZfightingFix = 0.1f;
    public GameObject canvas;
    public float size = 1f;
    [HideInInspector]
    public bool flag;
    [HideInInspector]
    public GameObject finger;

    //public RenderTexture RT;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
           // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
          //  if (Physics.Raycast(ray, out hit))
           // {
                var go = Instantiate(brush, finger.transform.position + canvas.transform.forward*-1 * ZfightingFix, Quaternion.FromToRotation(Vector3.up, canvas.transform.forward * -1), canvas.transform);
                go.transform.localScale = Vector3.one * size;
                //StartCoroutine(coSave(go));
           // }
        }
    }
    
        /* private IEnumerator coSave(GameObject go)
         {
             yield return new WaitForEndOfFrame();
             //Save?
             var texture2d = new Texture2D(RT.width, RT.height);
             texture2d.ReadPixels(new Rect(0, 0, RT.width, RT.height), 0, 0);
             texture2d.Apply();
             var data = texture2d.EncodeToPNG();
             File.WriteAllBytes(Application.dataPath + "/square.png", data);
             Destroy(go);
         }*/

    }
