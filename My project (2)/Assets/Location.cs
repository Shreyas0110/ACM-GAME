using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public string GPSStatus;
    public float latitudeValue;
    public float longitudeValue;
    public float altitudeValue;
    public float horizontalAccuracyValue;
    public double timeStampValue;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GPSLoc());
    }

    // Update is called once per frame
    IEnumerator GPSLoc()
    {
        while (!UnityEditor.EditorApplication.isRemoteConnected)
        {
            yield return null;
        }

        Debug.Log('e');

        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            GPSStatus = "Time Out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus = "Unable to determine device location";
            yield break;
        }
        else
        {
            GPSStatus = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }

    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus = "Running";
            latitudeValue= Input.location.lastData.latitude;
            longitudeValue = Input.location.lastData.longitude;
            altitudeValue = Input.location.lastData.altitude;
            horizontalAccuracyValue = Input.location.lastData.horizontalAccuracy;
            timeStampValue = Input.location.lastData.timestamp;

            Debug.Log(latitudeValue);
            Debug.Log(longitudeValue);
        }
        else
        {
            GPSStatus = "Stop";
        }
    }
}
