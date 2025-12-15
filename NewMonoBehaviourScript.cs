using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    bool isInside = false;
    public GameObject cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            cube.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
