using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isClosed;

    private MeshRenderer refMesh;
    private Collider refCollider;

    private void Start()
    {
        refMesh = GetComponent<MeshRenderer>();
        refCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = 
            collision.collider.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.hasKey == true)
            {
                Open();
                player.hasKey = false;
            }
        }
    }

    private void Update()
    {
        refMesh.enabled = isClosed;
        refCollider.enabled = isClosed;
    }

    public void Open()
    {
        isClosed = false;
    }

    public void Close()
    {
        isClosed = true;
    }
}
