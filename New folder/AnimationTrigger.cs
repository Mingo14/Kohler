using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator m_animator = null;
    [SerializeField] string m_tag = "";
    [SerializeField] string m_perameter = "";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(m_tag))
        {
            m_animator.SetBool(m_perameter, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(m_tag))
        {
            m_animator.SetBool(m_perameter, false);
        }
    }
}
