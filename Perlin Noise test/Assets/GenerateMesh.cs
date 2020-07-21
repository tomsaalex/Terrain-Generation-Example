using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMesh : MonoBehaviour
{
    Mesh terrain;
    Vector3[] vertices;
    int[] triangles;

    public int size = 100;

    void Start()
    {
        terrain = new Mesh();
        GetComponent<MeshFilter>().mesh = terrain;
        vertices = new Vector3[size * size];
        triangles = new int[size * size * 6];

        CreateShape();
        UpdateShape();
    }

    void CreateShape()
    {
        /*vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0)
        };

        triangles = new int[]
        {
            0, 1, 2
        };*/

        for(int z = 0; z < size ; z++)
        {
            for(int x = 0; x < size; x++)
            {
                vertices[z * size + x] = new Vector3(x, 0, z);
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = new Vector3(x, y, 0);
            }
        }

        int verts = 0, tris = 0;

        for (int x = 0; x < size - 1; x++)
        {
            for (int z = 0; z < size - 1; z++)
            {
                triangles[tris + 0] = 0 + verts;
                triangles[tris + 1] = size + verts;
                triangles[tris + 2] = 1 + verts;
                triangles[tris + 3] = 1 + verts;
                triangles[tris + 4] = size + verts;
                triangles[tris + 5] = 1 + size + verts;
                verts++;
                tris += 6;
            }
            verts++;
        }

        for(int x = 0; x < size; x++)
            for(int z = 0; z < size; z++)
            {
                ;
            }
    }

    void UpdateShape()
    {
        terrain.Clear();

        terrain.vertices = vertices;
        terrain.triangles = triangles;
    }
}
