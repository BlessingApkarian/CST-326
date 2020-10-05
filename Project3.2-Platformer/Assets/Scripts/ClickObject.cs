using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public float force = 5;
    public static bool qClicked = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    Debug.Log(hit.transform.name);
                    Destroy(hit.collider.gameObject);
                    if (hit.transform.name.ToString() == "Brick")
                    {
                        Debug.Log("DESTROY!!!");
                        Destroy(hit.collider.gameObject);
                    } else
                    {
                        Debug.Log("Punch");
                        qClicked = true;
                        Rigidbody rb; 
                        if(rb = hit.transform.GetComponent<Rigidbody>()){
                            PunchUp(rb);
                        }
                    }
                }
            }
        }
    }

    private void PunchUp(Rigidbody rig)
    {
        Debug.Log("HIT");
        rig.AddForce(rig.transform.up * force, ForceMode.Impulse);
    }
}
