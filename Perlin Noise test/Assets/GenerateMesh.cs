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

        for(int z = 0; z < size ; z++)
        {
            for(int x = 0; x < size; x++)
            {
                vertices[z * size + x] = new Vector3(x, 0, z);
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

        /*for(int x = 0; x < size; x++)
            for(int z = 0; z < size; z++)
            {
                vertices[x * size + z].y = Random.Range(0f, 10f);
            }
            */
    }

    void UpdateShape()
    {
        terrain.Clear();

        terrain.vertices = vertices;
        terrain.triangles = triangles;
    }
}
