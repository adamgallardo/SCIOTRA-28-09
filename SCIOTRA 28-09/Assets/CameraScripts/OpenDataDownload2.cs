using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class OpenDataDownload2 : MonoBehaviour
{
    [SerializeField]
    GameObject poiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetOpenData());
    }
    public void DownLoadData()
    {
        StartCoroutine(GetOpenData());
    }
    IEnumerator GetOpenData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.bsmsa.eu/ext/api/bsm/chargepoints/locations");
        www = UnityWebRequest.Get("https://www.bcn.cat/tercerlloc/files/NP-NASIA/opendatabcn_NP-NASIA_area-esbarjo-gossos-js.json");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Or retrieve results as binary text
            // JObject obj = JObject.Parse(www.downloadHandler.text);
            String arrayObject = "{\"punts\":" + www.downloadHandler.text+'}';
            JObject obj = JObject.Parse(arrayObject);
            JArray chargePoints = (JArray)obj["punts"];
            
            JObject location = (JObject)chargePoints.GetItem(0)["geo_epgs_4326"];
            GameObject poi = Instantiate(poiPrefab);
            poi.GetComponent<PoiScript2>().latitude = Convert.ToDouble(location["x"]);
            poi.GetComponent<PoiScript2>().longitude = Convert.ToDouble(location["y"]);
            poi.GetComponent<PoiScript2>().description = location["x"] + "-" + location["y"];
            poi.GetComponent<PoiScript2>().SendMessage("MapLocation");

            
            location = (JObject)chargePoints.GetItem(1)["geo_epgs_4326"];
            poi = Instantiate(poiPrefab);
            poi.GetComponent<PoiScript2>().latitude = Convert.ToDouble(location["x"]);
            poi.GetComponent<PoiScript2>().longitude = Convert.ToDouble(location["y"]);
            poi.GetComponent<PoiScript2>().description = location["x"] + "-" + location["y"];
            poi.GetComponent<PoiScript2>().SendMessage("MapLocation");

            location = (JObject)chargePoints.GetItem(2)["geo_epgs_4326"];
            poi = Instantiate(poiPrefab);
            poi.GetComponent<PoiScript2>().latitude = Convert.ToDouble(location["x"]);
            poi.GetComponent<PoiScript2>().longitude = Convert.ToDouble(location["y"]);
            poi.GetComponent<PoiScript2>().description = location["x"] + "-" + location["y"];
            poi.GetComponent<PoiScript2>().SendMessage("MapLocation");
/*
            location = (JObject)chargePoints.GetItem(3)["coordinates"];
            poi = Instantiate(poiPrefab);
            poi.GetComponent<PoiScript>().latitude = Convert.ToDouble(location["latitude"]);
            poi.GetComponent<PoiScript>().longitude = Convert.ToDouble(location["longitude"]);
            poi.GetComponent<PoiScript>().SendMessage("MapLocation");
*/
        }
    }
}

