using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanControl : MonoBehaviour
{

    private Animator animator;
    public float moveAmplify = 1; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player is pressing left/right keys
        float move = Input.GetAxis("Horizontal") * moveAmplify;
        if(move < 0 || move > 0)
        {
            animator.SetBool("isWalking", true);
        }
        //float y = (move < 0) ? 100 : 0;
        //Vector3 input = new Vector3(0, y, 0);
        //transform.eulerAngles = input;

        animator.SetFloat("Speed", Mathf.Abs(move));
        
    }
}
