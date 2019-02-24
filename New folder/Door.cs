using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AudioSource m_open = null;
    [SerializeField] AudioSource m_close = null;

    public void PlayOpenSFX()
    {
        m_open.Play();
    }

    public void PlayCLoseSFX()
    {
        m_close.Play();
    }
}
