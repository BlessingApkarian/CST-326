using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNPC : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("NPC"))
                    {
                        Debug.Log("right click to speak to NPC");
                    }

                    if (hit.transform.CompareTag("hitable"))
                    {
                        Debug.Log("right click to attack");
                    }

                    if (hit.transform.CompareTag("collectable"))
                    {
                        Debug.Log("right click to gather items");
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) // right mouse button (middle is 2)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("NPC"))
                    {
                        OpenDialog();
                    }

                    if (hit.transform.CompareTag("hitable"))
                    {
                        DoDamage();
                    }

                    if (hit.transform.CompareTag("collectable"))
                    {
                        GatherItems();
                    }
                }
            }
        }
    }

    void OpenDialog()
    {
        Debug.Log("Hello Izabelle");
    }

    void DoDamage()
    {
        Debug.Log("Damage Done: ");
    }

    void GatherItems()
    {
        Debug.Log("Gathered: ");
    }

}
