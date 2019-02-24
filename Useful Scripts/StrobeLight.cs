using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    [SerializeField] Light[] m_stobeLights = null;
    [SerializeField] [Range(0,60)] int m_frameDelay = 0;

    private int counter = 0;

    private void Start()
    {
        counter = m_frameDelay;
    }
    private void FixedUpdate()
    {
        counter--;
        if (counter <= 0)
        {
            counter = m_frameDelay;
            for (int i = 0; i < m_stobeLights.Length; i++)
            {
                m_stobeLights[i].color = new Color(Random.value * 255, Random.value * 255, Random.value * 255);
            }
        }
    }
}
