using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterJump : MonoBehaviour
{
    [SerializeField] GameObject m_coaster = null;
    [SerializeField] [Range(1,10)] float m_jumpPower = 0.0f;

    private Rigidbody m_rb = null;
    private void Start()
    {
        m_rb = m_coaster.GetComponent<Rigidbody>();
        
    }
    private void OnMouseDown()
    {
        m_rb.velocity += Vector3.up * m_jumpPower;
    }
}
