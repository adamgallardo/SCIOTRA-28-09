using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class ExempleJSON : MonoBehaviour
{
    [SerializeField]
    GameObject poiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetOpenData());
    }
    public void DownLoadData()
    {
        StartCoroutine(GetOpenData());
    }
    IEnumerator GetOpenData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.bcn.cat/tercerlloc/files/opendatabcn_agenda.json");
        www = UnityWebRequest.Get("https://www.bcn.cat/tercerlloc/files/cultura/opendatabcn_cultura_espais-de-musica-i-copes-js.json");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Or retrieve results as binary text
            String jsonText = "{info:"+www.downloadHandler.text +"}";
            JObject obj = JObject.Parse(jsonText);
            JArray activities = (JArray)obj["info"];
            String name;
            int cont = 0;
            foreach (JObject o in activities)
            {
                name = (String)o["name"];
                String geolocalitzacioX = (String)o["geo_epgs_4326"]["x"];
                String geolocalitzacioY = (String)o["geo_epgs_4326"]["y"];
                JArray addresses = (JArray)o["addresses"];
                String districte = (string)addresses[0]["district_name"];
                Debug.Log("Name "+ districte+ "-"+geolocalitzacioX+"  -   "+geolocalitzacioY+"   -   "+ name );
                cont++;  
            }
            Debug.Log("Num registres"+cont);

        
        }
    }
}

