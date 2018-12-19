using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    // variables
    public MeshRenderer refKeyHat;
    //expose to the inspector
    public float moveSpeed = 10f;
    public float jump;

    public bool hasKey;

    private Rigidbody refbody;
    private bool isGrounded;
    // monobehaviour functions

    private void Start ()
    {
        //finds the rigidbody component on the GameObject
        refbody = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate ()
    {
        UpdateKey();
        Move();
        Jump();
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9)
        {
            isGrounded = true;
        }
    }

    // other functions
    private void UpdateKey()
    {
        refKeyHat.enabled = hasKey;
    }

    private void Move()
    {
        //get input from the player
        //from Unity's InputManager
        Vector3 input = new Vector3
        (
            Input.GetAxis("Horizontal"),
            0f,
            Input.GetAxis("Vertical")
        );

        //calculate the velocity change
        Vector3 targetVelocity = input.normalized * moveSpeed;
        Vector3 velocityChange = targetVelocity - refbody.velocity;

        velocityChange.y = 0f;
        //apply
        refbody.AddForce(velocityChange, ForceMode.VelocityChange);

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            refbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // 0f, 1f, 0f
        }

        isGrounded = false;
    }

    

    //To edit gravity
    //edit -> projectSettings -> Physics

    /*
    Happens after the Update function 
    private void LateUpdate()
    {
        
    }
    
    Happens before Start function
    private void Awake()
    {
        
    }
    */
}
