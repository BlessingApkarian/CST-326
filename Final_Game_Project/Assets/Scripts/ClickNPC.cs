using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNPC : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.tag.Equals("NPC"))
                    {
                        OpenDialog();
                    }
                }
            }
        }
    }

    void OpenDialog()
    {
        Debug.Log("Hello Izabelle");
    }

}
