using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject groundAsset;
    public GameObject cornerAsset;

    public int length;
    public int width;

    private const int GROUND_SIZE = 2;

    public void Generate()
    {
        Clear(); //Delete all

        for (int x = 0; x < length; x++)
        {
            for (int z = 0; z < width; z++)
            {
                GameObject obj = Instantiate(groundAsset, gameObject.transform);
                obj.transform.position = new Vector3(x*GROUND_SIZE, 0, z*GROUND_SIZE);
                obj.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    public void Clear()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
