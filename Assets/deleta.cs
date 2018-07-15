using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleta : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("deleta"))
            Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("deleta"))
            Destroy(gameObject);
    }
}