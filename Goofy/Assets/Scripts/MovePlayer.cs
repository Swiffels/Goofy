using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{   
    // Get Objs from Unity
    private Rigidbody rb;
    public Transform orientation;
    public LayerMask groundLayer;

    // Movement vars
    private float horizInput;
    private float vertInput;
    public float moveSpeed;
    Vector3 moveDir;
    public float dragAmnt;

    // Ground Vars
    private bool grounded;
    public float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement for key input
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    
        // Speed Control
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed){
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.y);
        }

        // Ground check + drag
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight *0.5f + 0.3f, groundLayer);
        if(grounded)
            rb.drag = dragAmnt;
        else
            rb.drag = 0;

        Debug.Log(rb.velocity.magnitude);
    }

    void FixedUpdate()
    {
        moveDir = orientation.forward * vertInput + orientation.right * horizInput;
        rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Force);
    }
}
