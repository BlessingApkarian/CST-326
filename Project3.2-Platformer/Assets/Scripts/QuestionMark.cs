using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    private Material myQmaterial;
    public float amplify = 1;
    private float yValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        myQmaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        yValue += 1 * amplify * Time.deltaTime;

        if (yValue > 20)
        {
            // x stays the same, manipulate y
            myQmaterial.mainTextureOffset = new Vector2(1, (myQmaterial.mainTextureOffset.y + 0.2f) % 1);
            yValue = 1;
        }
    }
}
