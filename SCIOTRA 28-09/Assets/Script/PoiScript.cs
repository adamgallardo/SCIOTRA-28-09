using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoiScript : MonoBehaviour
{
	public double latitude;
	public double longitude;
	public string description;
    public string name;
    public string street;
    private TextChanger textChanger;

    [SerializeField] public TextMeshProUGUI namePlace, locationPlace;
   
    private void Start()
    {
        textChanger = FindObjectOfType<TextChanger>();
    }

	public void MapLocation(){
		Debug.Log("Point of interest located in the map");

        double x = Math.Floor(MapManager.TileX);
        double y = Math.Floor(MapManager.TileY);
        int zoom = MapManager.zoom;

        double a = DrawCubeX(longitude, TileToWorldPos(x, y, zoom).X, TileToWorldPos(x + 1, y, zoom).X);
        double b = DrawCubeY(latitude, TileToWorldPos(x, y + 1, zoom).Y, TileToWorldPos(x, y, zoom).Y);

        this.transform.position = new Vector3((float)a - 0.5f, (float)b - 0.5f, 0.0f);
    }
    public struct Point
    {
        public double X;
        public double Y;
    }
    public Point TileToWorldPos(double tile_x, double tile_y, int zoom)
    {
        Point p = new Point();
        double n = System.Math.PI - ((2.0 * System.Math.PI * tile_y) / System.Math.Pow(2.0, zoom));

        p.X = ((tile_x / System.Math.Pow(2.0, zoom) * 360.0) - 180.0);
        p.Y = (180.0 / System.Math.PI * System.Math.Atan(System.Math.Sinh(n)));

        return p;
    }

    public double DrawCubeY(double targetLat, double minLat, double maxLat)
    {
        double pixelY = ((targetLat - minLat) / (maxLat - minLat));
        return pixelY;
    }

    public double DrawCubeX(double targetLong, double minLong, double maxLong)
    {
        double pixelX = ((targetLong - minLong) / (maxLong - minLong));
        return pixelX;
    }
    private void OnMouseDown()
    {
        Debug.Log(name);
        Debug.Log(street);

        if (textChanger != null)
        {
            textChanger.UpdateText(name.ToString(), street.ToString());
        }
    }
}

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class PoiScript : MonoBehaviour
// {
// 	public double latitude;
// 	public double longitude;
// 	public string description;
//     public string name;
//     public string street;
//     private TextChanger textChanger;

//     [SerializeField] public TextMeshProUGUI namePlace, locationPlace;
   
//     private void Start()
//     {
//         textChanger = FindObjectOfType<TextChanger>();
//     }

//     private void Update()
//     {
//         // Verificar si hay toques en la pantalla
//         if (Input.touchCount > 0)
//         {
//             // Solo considerar el primer toque
//             Touch touch = Input.GetTouch(0);

//             // Verificar si se tocó la pantalla
//             if (touch.phase == TouchPhase.Began)
//             {
//                 // Llamar al método en TextChanger para actualizar los TextMeshProUGUI
//                 HandleTouch();
//             }
//         }
//     }

// 	public void MapLocation(){
// 		Debug.Log("Point of interest located in the map");

//         double x = Math.Floor(MapManager.TileX);
//         double y = Math.Floor(MapManager.TileY);
//         int zoom = MapManager.zoom;

//         double a = DrawCubeX(longitude, TileToWorldPos(x, y, zoom).X, TileToWorldPos(x + 1, y, zoom).X);
//         double b = DrawCubeY(latitude, TileToWorldPos(x, y + 1, zoom).Y, TileToWorldPos(x, y, zoom).Y);

//         this.transform.position = new Vector3((float)a - 0.5f, (float)b - 0.5f, 0.0f);
//     }
//     public struct Point
//     {
//         public double X;
//         public double Y;
//     }
//     public Point TileToWorldPos(double tile_x, double tile_y, int zoom)
//     {
//         Point p = new Point();
//         double n = System.Math.PI - ((2.0 * System.Math.PI * tile_y) / System.Math.Pow(2.0, zoom));

//         p.X = ((tile_x / System.Math.Pow(2.0, zoom) * 360.0) - 180.0);
//         p.Y = (180.0 / System.Math.PI * System.Math.Atan(System.Math.Sinh(n)));

//         return p;
//     }

//     public double DrawCubeY(double targetLat, double minLat, double maxLat)
//     {
//         double pixelY = ((targetLat - minLat) / (maxLat - minLat));
//         return pixelY;
//     }

//     public double DrawCubeX(double targetLong, double minLong, double maxLong)
//     {
//         double pixelX = ((targetLong - minLong) / (maxLong - minLong));
//         return pixelX;
//     }
//     private void HandleTouch()
//     {
//         Debug.Log(name);
//         Debug.Log(street);

//         // Verificar si se encontró el script TextChanger
//         if (textChanger != null)
//         {
//             // Llamar a un método en TextChanger para actualizar los TextMeshProUGUI
//             textChanger.UpdateText(name.ToString(), street.ToString());
//         }
//     }
// }
