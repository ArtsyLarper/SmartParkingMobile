using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ParkingSpace : MonoBehaviour
{
    public Vector3 zero;
    public Vector3 one;
    public Vector3 two;
    public Vector3 three;
    public DatabaseReference positions;
    public Shader shader;
    public bool taken = false;
    private Collider2D crash;
    // Start is called before the first frame update

    public void PaintLot()
    {
        Debug.Log("parking spot");

        Mesh ParkingSpace = new Mesh();
        GetComponent<MeshFilter>().mesh = ParkingSpace;
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = zero;
        vertices[1] = one;
        vertices[2] = two;
        vertices[3] = three;

        uv[0] = new Vector2(zero.x, zero.y);
        uv[1] = new Vector2(one.x, one.y);
        uv[2] = new Vector2(two.x, two.y);
        uv[3] = new Vector2(three.x, three.y);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;


        ParkingSpace.vertices = vertices;
        ParkingSpace.uv = uv;
        ParkingSpace.triangles = triangles;

        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        UnityEngine.Color[] colors = new UnityEngine.Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = UnityEngine.Color.green;

        // assign the array of colors to the Mesh.
        mesh.colors = colors;
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        collider.points = uv;

        //GetComponent<MeshRenderer>().material = new UnityEngine.Material(shader);
        //GetComponent<MeshRenderer>().material.color = UnityEngine.Color.clear;
    }

    void Start()
    {
        Debug.Log("parking spot");

        Mesh ParkingSpace = new Mesh();
        GetComponent<MeshFilter>().mesh = ParkingSpace;
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = zero;
        vertices[1] = one;
        vertices[2] = two;
        vertices[3] = three;

        uv[0] = new Vector2(zero.x, zero.y);
        uv[1] = new Vector2(one.x, one.y);
        uv[2] = new Vector2(two.x, two.y);
        uv[3] = new Vector2(three.x, three.y);

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        //LineRenderer outline = gameObject.AddComponent<LineRenderer>(); 
        //outline.SetPositions(vertices);
        

        ParkingSpace.vertices = vertices;
        ParkingSpace.uv = uv;
        ParkingSpace.triangles = triangles;

        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        UnityEngine.Color[] colors = new UnityEngine.Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = UnityEngine.Color.green;

        // assign the array of colors to the Mesh.
        mesh.colors = colors;

        //GetComponent<MeshRenderer>().material.color = UnityEngine.Color.green;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision started with" + collision.name);
        if (collision.tag == "ParkingSpot" || taken) return;
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        UnityEngine.Color[] colors = new UnityEngine.Color[mesh.vertices.Length];

        for (int i = 0; i < mesh.vertices.Length; i++)
            colors[i] = UnityEngine.Color.red;

        Debug.Log("trigger enter");
        // assign the array of colors to the Mesh.
        mesh.colors = colors;
        //GetComponent<MeshRenderer>().material.color = UnityEngine.Color.red;
        if (!taken) { 
        crash = collision; }
        taken = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
       
        Debug.Log("Collision ended with" + collision.name);
        if ((collision.tag == "ParkingSpot" || !taken) && collision != crash) return;
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        UnityEngine.Color[] colors = new UnityEngine.Color[mesh.vertices.Length];

        for (int i = 0; i < mesh.vertices.Length; i++)
            colors[i] = UnityEngine.Color.green;

        // assign the array of colors to the Mesh.
        mesh.colors = colors;
        //GetComponent<MeshRenderer>().material.color = UnityEngine.Color.green;
        taken = false;
    }
}
