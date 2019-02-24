using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    [SerializeField] [Range(1, 50)] float m_force = 1.0f;
    [SerializeField] AudioSource m_flySound = null;

    Rigidbody m_rb = null;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translate = Vector3.zero;
        float power = Input.GetAxis("FlyForce");

        if(power != 0.0f)
        {
            if(m_flySound.isPlaying == false) m_flySound.Play();
            m_flySound.volume = power;
            m_flySound.pitch = 1 + power;
        }
        else
        {
            m_flySound.Stop();
        }

        translate.y = power * m_force;
        m_rb.AddForce(transform.rotation * translate, ForceMode.Acceleration);
    }
}
