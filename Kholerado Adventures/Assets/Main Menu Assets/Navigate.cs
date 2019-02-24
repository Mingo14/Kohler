using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigate : MonoBehaviour
{
    [SerializeField]
    private Camera cameraToActivate;
    [SerializeField]
    private Camera mainCamera;
    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        mainCamera.enabled = false;
        cameraToActivate.enabled = true;
    }
}
