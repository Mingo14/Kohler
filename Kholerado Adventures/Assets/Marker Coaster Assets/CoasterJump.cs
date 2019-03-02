using UnityEngine;

public class CoasterJump : MonoBehaviour
{
    [SerializeField] private GameObject m_coaster = null;
    [SerializeField] [Range(1, 10)] private float m_jumpPower = 0.0f;
    [SerializeField] private Camera MainMenuCamera = null;
    [SerializeField] private Camera thisCamera = null;
    private int m_lives = 3;

    private Rigidbody m_rb = null;
    private void Start()
    {
        m_rb = m_coaster.GetComponent<Rigidbody>();

    }
    private void OnMouseDown()
    {
        m_rb.velocity += Vector3.up * m_jumpPower;
    }

    public void Kill()
    {
        m_lives--;
        if (m_lives <= 0)
        {
            MainMenuCamera.enabled = true;
            thisCamera.enabled = false;
        }
        Debug.Log(m_lives);
    }
}
