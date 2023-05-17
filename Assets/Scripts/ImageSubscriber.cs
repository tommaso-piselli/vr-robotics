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

        BgrToRgb(imageBytes);
        Flip180(imageBytes);

        texture.LoadRawTextureData(imageBytes);
        texture.Apply();
        rawImage.texture = texture;
    }

    public void BgrToRgb(byte[] data)
    {
        for (int i = 0; i < data.Length; i += 3)
        {
            byte dummy = data[i];
            data[i] = data[i + 2];
            data[i + 2] = dummy;
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