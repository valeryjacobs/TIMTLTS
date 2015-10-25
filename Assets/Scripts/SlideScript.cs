using UnityEngine;
using System.Collections;
using System.IO;

public class SlideScript : MonoBehaviour
{
    public string pathTemplate;
    Renderer rend;
    int slideIndex = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            slideIndex++;
            SetSlide();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (slideIndex > 1)
            {
                slideIndex--;
                SetSlide();
            }
        }
    }

    private void SetSlide()
    {
        var path = string.Format(pathTemplate, slideIndex.ToString());

        if (File.Exists(path))
        {
            rend = GetComponent<Renderer>();
            rend.material.mainTexture = LoadPNG(path);

        }
    }

    public static Texture2D LoadPNG(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;

        fileData = File.ReadAllBytes(filePath);
        tex = new Texture2D(2, 2);
        tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

        return tex;
    }
}
