using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] GameObject m_projectile = null;
    [SerializeField] AudioSource m_fireSFX = null;

    [SerializeField] [Range(0.0f, 5.0f)] float m_rotationRate = 2.0f;
    [SerializeField] [Range(0.0f, 5.0f)] float m_fireRate = 1.0f;

    GameObject m_target = null;

    float fireTimer { get; set; }

    void Start()
    {
        fireTimer = m_fireRate;
    }

    void Update()
    {
        if(m_target)
        {
            Vector3 direction = m_target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * m_rotationRate);

            fireTimer = fireTimer - Time.deltaTime;
            if(fireTimer <= 0.0)
            {
                fireTimer = m_fireRate;

                if(m_fireSFX)
                {
                    m_fireSFX.Play();
                }
                Instantiate(m_projectile, m_muzzle.position, m_muzzle.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_target = null;
        }
    }
}
