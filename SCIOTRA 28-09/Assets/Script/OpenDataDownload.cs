using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

public class OpenDataDownload : MonoBehaviour
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
        UnityWebRequest www = UnityWebRequest.Get("https://www.bcn.cat/tercerlloc/files/cultura/opendatabcn_cultura_espais-de-musica-i-copes-js.json");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Or retrieve results text
             String jsonText = "{info:"+www.downloadHandler.text +"}";
            JObject obj = JObject.Parse(jsonText);
            JArray activities = (JArray)obj["info"];
            String name;
            String latitud = null;
            string longitud = null;
            string street = null;
            string number = null;
           
            int cont = 0;
            foreach (JObject o in activities)
            {
                name = (String)o["name"];
                latitud = (String)o["geo_epgs_4326"]["x"];
                longitud = (String)o["geo_epgs_4326"]["y"];
                JArray addresses = (JArray)o["addresses"];
                String districte = (string)addresses[0]["district_name"];
                street = (string)addresses[0]["address_name"];

                number = (string)addresses[0]["start_street_number"];
                Debug.Log("Name "+ districte+ "-"+latitud+"  -   "+longitud+"   -   "+ name );

                GameObject poi = Instantiate(poiPrefab);
                poi.GetComponent<PoiScript>().latitude = Convert.ToDouble(latitud, CultureInfo.InvariantCulture);
                poi.GetComponent<PoiScript>().longitude = Convert.ToDouble(longitud, CultureInfo.InvariantCulture);
                poi.GetComponent<PoiScript>().name = name;
                poi.GetComponent<PoiScript>().SendMessage("MapLocation");
                poi.GetComponent<PoiScript>().street= street+" "+number;
                
                cont++;  
            }
            Debug.Log("Num registres"+cont);

           

        }
    }
}

