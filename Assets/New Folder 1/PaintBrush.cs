using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaintBrush : MonoBehaviour
{
    public int resolution = 512;
    Texture2D whiteMap;
    public RenderTexture rt;
    public float brushSize;
    public Texture2D brushTexture;
    Vector2 stored;
    float xCoordinate;
    float yCoordinate;
    public RawImage rawImage;
    
    public static Dictionary<Collider, RenderTexture> paintTextures = new Dictionary<Collider, RenderTexture>();
    void Start()
    {
        CreateClearTexture();// clear white texture to draw on
    }

    void Update()
    {

        xCoordinate = Mathf.Floor(Input.mousePosition.x-rawImage.rectTransform.position.x);
        yCoordinate = Mathf.Floor(Input.mousePosition.y-rawImage.rectTransform.position.y);
        DrawTexture(rt, xCoordinate, yCoordinate);
        
    }

    void DrawTexture(RenderTexture rt, float posX, float posY)
    {
        RenderTexture.active = rt; // activate rendertexture for drawtexture;
        GL.PushMatrix();                       // save matrixes
        GL.LoadPixelMatrix(0,resolution, resolution, 0);      // setup matrix for correct size
        
        // draw brushtexture
        Graphics.DrawTexture(new Rect(posX - brushTexture.width / brushSize, (rt.height - posY) - brushTexture.height / brushSize, brushTexture.width / (brushSize * 0.5f), brushTexture.height / (brushSize * 0.5f)), brushTexture);
        GL.PopMatrix();
        RenderTexture.active = null;// turn off rendertexture


    }

    RenderTexture getWhiteRT()
    {
        RenderTexture rt = new RenderTexture(resolution, resolution, 32);
        Graphics.Blit(whiteMap, rt);
        return rt;
    }

    void CreateClearTexture()
    {
        whiteMap = new Texture2D(1, 1);
        whiteMap.SetPixel(0, 0, Color.white);
        whiteMap.Apply();
    }
}