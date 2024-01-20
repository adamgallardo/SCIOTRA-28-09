// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;
// using System;
// using System.Diagnostics;

// public class MapManager : MonoBehaviour
// {
//     [SerializeField]
//     GameObject centerMap;
//     [SerializeField]
//     GameObject right;

//     public static double TileX;
//     public static double TileY;
//     public static int zoom;

//     // Start is called before the first frame update
//     void Start()
//     {

//         zoom = 15;
//         GetTile(Input.location.lastData.latitude, Input.location.lastData.longitude);
//         StartCoroutine(GetOpenStreetMap());
//     }

//     IEnumerator GetOpenStreetMap()
//     {
//  	    UnityEngine.Debug.Log("https://a.tile.openstreetmap.org/" + zoom + "/" + Math.Floor(TileX) + "/" +Math.Floor(TileY) + ".png");

//         UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://a.tile.openstreetmap.org/"+zoom+"/"+Math.Floor(TileX)+"/"+Math.Floor(TileY)+".png");
//         yield return www.SendWebRequest();

//         if (www.result == UnityWebRequest.Result.ConnectionError)
//         {
//             UnityEngine.Debug.Log(www.error);
//         }
//         else
//         {
//             Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
//             centerMap.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", myTexture);
//         }

//         www = UnityWebRequestTexture.GetTexture("https://a.tile.openstreetmap.org/" + zoom + "/" + Math.Floor(TileX+1) + "/" + Math.Floor(TileY) + ".png");
//         yield return www.SendWebRequest();

//         if (www.result == UnityWebRequest.Result.ConnectionError)
//         {
//             UnityEngine.Debug.Log(www.error);
//         }
//         else
//         {
//             Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
//             right.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", myTexture);
//         }

//         GameObject openDataloader = GameObject.Find("OpenData");
//         openDataloader.GetComponent<OpenDataDownload>().SendMessage("DownLoadData");


//     }

//     public void GetTile(double lat, double lon)
//     {
//         TileX = (float)((lon + 180.0) / 360.0 * (1 << zoom));
//         TileY = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) +
//         1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 <<
//         zoom));

//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Diagnostics;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    GameObject centerMap;
    [SerializeField]
    GameObject right;

    public static double TileX;
    public static double TileY;
    public static int zoom;

    // Start is called before the first frame update
    void Start()
    {

        zoom = 15;
        GetTile(41.40645,2.15223);
        StartCoroutine(GetOpenStreetMap());
    }

    IEnumerator GetOpenStreetMap()
    {
 	    UnityEngine.Debug.Log("https://a.tile.openstreetmap.org/" + zoom + "/" + Math.Floor(TileX) + "/" +Math.Floor(TileY) + ".png");

        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://a.tile.openstreetmap.org/"+zoom+"/"+Math.Floor(TileX)+"/"+Math.Floor(TileY)+".png");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            UnityEngine.Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            centerMap.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", myTexture);
        }

        www = UnityWebRequestTexture.GetTexture("https://a.tile.openstreetmap.org/" + zoom + "/" + Math.Floor(TileX+1) + "/" + Math.Floor(TileY) + ".png");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            UnityEngine.Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            right.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", myTexture);
        }

        GameObject openDataloader = GameObject.Find("OpenData");
        openDataloader.GetComponent<OpenDataDownload>().SendMessage("DownLoadData");


    }

    public void GetTile(double lat, double lon)
    {
        TileX = (float)((lon + 180.0) / 360.0 * (1 << zoom));
        TileY = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) +
        1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 <<
        zoom));

    }
}
