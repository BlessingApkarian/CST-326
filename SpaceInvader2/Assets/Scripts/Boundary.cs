using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    Camera cam;
    float width;
    float height;

    public EdgeCollider2D edge;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        edge = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FindBoundries();
        SetBounds();
    }

    void SetBounds()
    {
        Vector2 pointA = new Vector2(width / 2, height / 2);
        Vector2 pointB = new Vector2(width / 2, -height / 2);
        Vector2 pointC = new Vector2(-width / 2, -height / 2);
        Vector2 pointD = new Vector2(-width / 2, height / 2);

        Vector2[] tempArray = new Vector2[] { pointA, pointB, pointC, pointD, pointA };
        edge.points = tempArray;
    }

    void FindBoundries()
    {

        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);

    }
}
