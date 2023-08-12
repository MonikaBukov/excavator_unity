using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureInPicture : MonoBehaviour
{
    public enum compass { north, south, east, west };
    public enum hAligment { left, centre, right };
    public enum vAligment { top, middle, bottom };
    public hAligment horAlign = hAligment.left;
    public vAligment vertAlign = vAligment.top;
    public enum UnitsIn { pixels, screen_precentage };
    public UnitsIn unit = UnitsIn.screen_precentage;
    public int PiPwidth = 50;
    public int PiPheight = 50;
    public int xOffest = 0;
    public int yOffest = 0;
    private bool drawLine = false;
    Rect cameraRect;

    public bool update = true;
    private int hsize, vsize, hloc, vloc;
    void Start()
    {
        AdjustCamera();
    }

    void Update()
    {
        if (update)
        {
            AdjustCamera();
            drawLine = true;
        }
    }
    void AdjustCamera()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        float swPercent = sw * 0.01f;
        float shPrecent = sh * 0.01f;
        float xOffPercent = xOffest * swPercent;
        float yOffPercent = yOffest * shPrecent;
        int xOff;
        int yOff;

        if (unit == UnitsIn.screen_precentage)
        {
            hsize = PiPwidth * (int)swPercent;
            vsize = PiPheight * (int)shPrecent;
            xOff = (int)xOffPercent;
            yOff = (int)yOffPercent;
        }
        else
        {
            hsize = PiPwidth;
            vsize = PiPheight;
            xOff = xOffest;
            yOff = yOffest;
        }
        switch (horAlign)
        {
            case hAligment.left:
                hloc = xOff; break;
            case hAligment.right:
                int justifiedRight = (sw - hsize);
                hloc = justifiedRight - xOff;
                break;
            case hAligment.centre:
                float justifiedCenter = (sw * 0.5f) - (hsize * 0.5f);
                hloc = (int)(justifiedCenter - xOff);
                break;
        }
        switch (vertAlign)
        {
            case vAligment.top:
                int justifiedTop = sh - vsize;
                vloc = (int)(justifiedTop - yOff);
                break;
            case vAligment.bottom:
                vloc = sh - (int)(yOffPercent * shPrecent) - vsize;
                break;
            case vAligment.middle:
                float justifiedMiddle = (sh * 0.5f) - (vsize * 0.5f);
                vloc = (int)(justifiedMiddle - yOff);
                break;
        }
        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize); 

        cameraRect = new Rect(hloc, (vloc = Screen.height - vloc - vsize), hsize, vsize);

    }
    void OnGUI()
    {
        // Check if drawLine is true
        if (drawLine)
        {
            Camera camera = GetComponent<Camera>();
            if (camera && camera.isActiveAndEnabled)
            {
                // Draw a box around the camera using the GUI.Box method

                GUI.Box(cameraRect, "");
            }
        }
    }
}
