using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    GameObject manager;

    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.GetComponent<Winner>().enabled = true;
            Destroy(this.gameObject);
        }
    }

}
