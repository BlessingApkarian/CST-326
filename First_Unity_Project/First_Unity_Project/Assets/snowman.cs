using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowman : MonoBehaviour
{

    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float rgbLight = Input.GetAxis("Horizontal");

        if (rgbLight > 0) { // right arrow
            light.color = Color.red;
        } else if(rgbLight < 0) { // left arrow
            light.color = Color.green;
        } else { // no arrow / neutral
            light.color = Color.blue;
        }

        float cbyLight = Input.GetAxis("Vertical");

        if (cbyLight > 0) { // up arrow
            light.color = Color.magenta;
        }
        else if (cbyLight < 0) { // down arrow
            light.color = Color.black;
        }
    }
}
