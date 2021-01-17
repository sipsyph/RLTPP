using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.UI;
using TMPro;

public class FaceDetector : MonoBehaviour
{
    public TMP_Text XText, YText;
    WebCamTexture webCamtexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    void Start()
    {
        WebCamDevice [] devices = WebCamTexture.devices;

        webCamtexture = new WebCamTexture(devices[0].name);
        webCamtexture.Play();

        //cascade = new CascadeClassifier(Application.dataPath + @"/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
        //Assetshaarcascade_frontalface_default.xml
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = webCamtexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(webCamtexture);

        //findNewFace(frame);
    }

    // void findNewFace(Mat frame)
    // {
    //     var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

    //     if(faces.Length >= 1)
    //     {
    //         MyFace = faces[0];
    //         XText.text = "X: "+faces[0].X;
    //         YText.text = "Y: "+faces[0].Y;
    //     }
    // }

    // void display(Mat frame)
    // {
    //     if(MyFace != null)
    //     {
    //         frame.Rectangle(MyFace, new Scalar(250, 0, 0), 2);
            
    //     }

    //     Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
    //     GetComponent<Renderer>().material.mainTexture = webCamtexture;
    // }
}
