using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;

public class ImageSubscriber : MonoBehaviour
{
    //public string topicName = "/airsim_node/drone_1/front_left_custom/Scene";
    public string topicName = "/bluefox_camera/image_raw";

    private ROSConnection rosConnection;
    private Texture2D texture;
    public RawImage rawImage;

    void Start()
    {
        rosConnection = ROSConnection.GetOrCreateInstance();
        rosConnection.Subscribe<ImageMsg>(topicName, msg => OnImageReceived(msg));
    }

    void OnImageReceived(ImageMsg msg)
    {
        byte[] imageBytes = msg.data;

        texture = new Texture2D((int)msg.width, (int)msg.height, TextureFormat.RGB24, false);
        Debug.Log(msg.encoding);

        //BgrToRgb(imageBytes);
        Flip180(imageBytes);

        texture.LoadRawTextureData(imageBytes);
        texture.Apply();
        rawImage.texture = texture;
    }

    public void BgrToRgb(byte[] bgrImage)
    {
        // Calculate the number of pixels in the image
        int pixelCount = bgrImage.Length / 3;

        // Create an output RGB image array with the same size
        byte[] rgbImage = new byte[bgrImage.Length];

        // Convert BGR to RGB by swapping the red (R) and blue (B) channels for each pixel
        for (int i = 0; i < pixelCount; i++)
        {
            int bgrIndex = i * 3;
            int rgbIndex = i * 3;

            rgbImage[rgbIndex] = bgrImage[bgrIndex + 2];     // R channel
            rgbImage[rgbIndex + 1] = bgrImage[bgrIndex + 1]; // G channel
            rgbImage[rgbIndex + 2] = bgrImage[bgrIndex];     // B channel
        }
    }
        public void Flip180(byte[] data)
    {
        int length = data.Length;
        int halfLength = length / 2;
        for (int i = 0; i < halfLength; i++)
        {
            byte temp = data[i];
            data[i] = data[length - i - 1];
            data[length - i - 1] = temp;
        }
    }

}