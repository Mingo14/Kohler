using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 360.0f)] float m_rotateRate = 90.0f;
    [SerializeField] [Range(0.0f, 50.0f)] float m_maxSpeed = 10.0f;

    [SerializeField] [Range(0.0f, 360.0f)] float m_turretRotateRate = 20.0f;

    [SerializeField] Transform m_turret = null;
    [SerializeField] Transform m_nuzzle = null;

    [SerializeField] TextMeshProUGUI m_healthUI = null;

    [SerializeField] GameObject[] m_weapons = null;
    int m_weaponIndex = 0;
    
    void Update()
    {
        float rotate = 0.0f;
        float forward = 0.0f;
        float right = 0.0f;
        float up = 0.0f;

        if(Input.GetKey(KeyCode.A))
        {
            rotate = -m_rotateRate;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotate = m_rotateRate;
        }
        if (Input.GetKey(KeyCode.W))
        {
            forward = m_maxSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            forward = -m_maxSpeed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            right = -m_maxSpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            right = m_maxSpeed;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            
        }
        transform.rotation = transform.rotation * Quaternion.AngleAxis(rotate * Time.deltaTime, Vector3.up);
        Vector3 velocity = transform.rotation * new Vector3(right, up, forward);
        transform.position = transform.position + velocity * Time.deltaTime;

        for (int i = 0; i < m_weapons.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) m_weaponIndex = i;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = m_nuzzle.rotation * Quaternion.AngleAxis(0.0f, Vector3.right);
            Instantiate(m_weapons[m_weaponIndex], m_nuzzle.position, rotation);
        }

        m_turret.rotation = m_turret.rotation * Quaternion.AngleAxis(Input.GetAxis("Mouse X") * m_turretRotateRate * Time.deltaTime, Vector3.forward);

        float health = GetComponent<Health>().health / 100.0f;
        m_healthUI.text = "Health: " + health.ToString("P1");

        //m_healthUI.faceColor = new Color(Random.value * 255, Random.value * 255, Random.value * 255);
    }
}
