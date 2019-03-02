using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CoasterJump>().Kill();
        }
    }
}
