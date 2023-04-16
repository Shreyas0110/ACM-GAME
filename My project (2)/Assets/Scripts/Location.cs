using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string GPSStatus;
    public float latitudeValue = 0;
    public float longitudeValue = 0;
    public float altitudeValue = 0;
    public float horizontalAccuracyValue = 0;
    public double timeStampValue = 0;

    public float x;
    public float y;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GPSLoc());
    }

    // Update is called once per frame
    private void Update()
    {
        y = (latitudeValue - 37.00468f) / 0.00018182f + 89.2f;
        x = (longitudeValue + 122.05699f) / 0.00018182f + 5.7f;
        Vector3 position = new Vector3(x, y, -1f);
        transform.position = position;
    }
    
    /*IEnumerator GPSLoc()
    {
        while (!UnityEditor.EditorApplication.isRemoteConnected) 
        {
            yield return null;
        }

        Debug.Log("Connected!");

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
    */
}
