using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class EthanBlendController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float move = 1;

    public float amplify = 2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // controlls animation speed
        move = Input.GetAxis("Horizontal");
        move = (Input.GetKey(KeyCode.LeftShift)) ? move * amplify : move;
        animator.SetFloat("Speed", Mathf.Abs(move));

        // turn left or right
        float y = (move < 0) ? 100 : 0;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;
    }

    private void FixedUpdate()
    {
        //rb.AddForce((Vector3.forward * move), ForceMode.VelocityChange);
    }
}
