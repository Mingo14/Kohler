using UnityEngine;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private int counter = 0;
    private void OnMouseDown()
    {
        Debug.Log($"Mitch Conner{counter++}");
    }
}
