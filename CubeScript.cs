using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Material red;
    public Material green;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Renderer rnd = GetComponent<Renderer>();
            rnd.material = red;

            collision.gameObject.GetComponent<Renderer>().material = green;
        }
    }
}
