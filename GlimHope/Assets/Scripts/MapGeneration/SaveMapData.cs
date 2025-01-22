using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static MapData;

public class SaveMapData
{

    public List<int> mapData = new List<int>();

    public void SaveMapLayout(List<MapData.Index2TileData> map)
    {
        mapData.Clear();
        foreach (Index2TileData tile in map)
        {
            int data = new int();
            data = 10;

            //origin
            int movement = tile.index - tile.tileData.origin;
            int direction = 6;
            if (tile.tileData.roomType == 2)
            {
                direction = 6;
            }
            if(movement < 0) //left
            {
                direction = 1;
            }
            if (movement > 0) // right
            {
                direction = 2;
            }
            if (movement == 4) // up
            {
                direction = 3;
            }
            if (movement==-4) // need to add a down case
            {
                direction = 3;
            }
            if (tile.tileData.origin == 99)//start
            {
                direction = 5;
            }
            if (tile.tileData.origin == 16)//empty
            {
                direction = 6;
            }
            data = direction;

            movement = tile.index - tile.tileData.destination;

            if (tile.tileData.origin == 99)
            {
                movement = tile.index - tile.tileData.destination;
            }

            direction = 6;
            if (movement < 0) //left
            {
                direction = 1;
            }
            if (movement > 0) // right
            {
                direction = 2;
            }
            if (movement == 4) // up
            {
                direction = 3;
            }
            if (movement == -8 || movement == -4) // need to add a down case
            {
                direction = 3;
            }
            if (tile.tileData.destination == 99)//end
            {
                direction = 5;
            }
            if (tile.tileData.destination == 16)//empty
            {
                direction = 6;
            }
            data = (data * 10) + direction;
            //000000
            //room type
            data = (data * 10) + tile.tileData.roomType;
            //room variation
            data = (data * 10) + tile.tileData.roomVariation;
            mapData.Add(data);

            Debug.Log("Tile " + tile.index + " is assigned value of " + data);
        }

        Debug.Log("Layout saved");
    }
}
