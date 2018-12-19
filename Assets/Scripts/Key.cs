using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public PlayerController refPlayer;

    private void OnTriggerEnter(Collider other)
    {
        refPlayer.hasKey = true;

        Destroy(gameObject);
    }
}
