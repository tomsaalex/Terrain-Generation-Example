using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Generate_Texture : MonoBehaviour
{
    public int tex_width = 1000;
    public int tex_height = 1000;

    public float orgX = 1;
    public float orgY = 1;

    public float scale = 5.0f;

    Renderer rend;
    Texture2D noiseTexture;
    Color[] pix;

    void Start()
    {
        rend = GetComponent<Renderer>();

        noiseTexture = new Texture2D(tex_width, tex_height);
        pix = new Color[noiseTexture.width * noiseTexture.height];
        rend.material.mainTexture = noiseTexture;

    }

    public void CalculateNoise()
    {
        float y = 0;
        
        while (y < noiseTexture.height)
        {
            float x = 0;
            while (x < noiseTexture.width)
            {
                float xCoord = orgX + x / noiseTexture.width * scale;
                float yCoord = orgY + y / noiseTexture.height * scale;

                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                /*Color c;
                if (sample < 0.2)
                {
                    c = new Color(0, 0, 50);
                }
                else if (sample < 0.4)
                {
                    c = new Color(0, 50, 0);
                }
                else if (sample < 0.6)
                {
                    c = new Color(0, 50, 50);
                }
                else if (sample < 0.8)
                {
                    c = new Color(50, 50, 0);
                }
                else
                    c = new Color(50, 50, 50);*/
                pix[(int)x + (int)y * noiseTexture.width] = new Color(Mathf.Sin(sample * 2), Mathf.Tan(sample/2), Mathf.Cos(4 * sample));
                x++;
            }
            y++;
        }
        noiseTexture.SetPixels(pix);
        noiseTexture.Apply();

        var bytes = noiseTexture.EncodeToPNG();

        var dirPath = Application.dataPath + "/Assets";
        File.WriteAllBytes(dirPath + "-Texture.png", bytes);
    }

    
}
