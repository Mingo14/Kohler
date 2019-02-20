using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject m_door = null;
    private void OnTriggerEnter(Collider other)
    {
        m_door.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        m_door.SetActive(true);
    }
}
