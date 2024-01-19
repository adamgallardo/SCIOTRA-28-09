using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiScript : MonoBehaviour
{
	public double latitude;
	public double longitude;
	public string description;
    public string name;
    public string street;
    GameObject tablero;


    private void Start()
    {
        GameObject tablero = GameObject.Find("Tablero");
        tablero.SetActive(false);
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
    private void Click()
    {
        Debug.Log(name);
        Debug.Log(street);
        tablero.SetActive(true);
        tableroScript controller = tablero.GetComponent<tableroScript>();
        controller.Valores(name,street);
    }
}
