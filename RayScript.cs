using System.Threading;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    Ray ray;

    RaycastHit hit;
    
    public LayerMask mask;

    void Update()
    {
        if (PauseMenu.isPaused) return;

        ray = new Ray(transform.position, transform.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 10f, mask))
            {

                if (hit.collider.gameObject.layer == 6)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.red;
                }
                if (hit.collider.gameObject.layer == 7)
                {
                    if (hit.collider.gameObject == GameManager.Instance.Target)
                    {
                        UIManager.Instance.AddPoints(); 
                    }
                    else
                    {
                        UIManager.Instance.RemovePoints();
                    }
                    GameManager.Instance.SelectTarget();
                }
                // 1/ Timer v gamemanageru na sebrani
                // 2/ timer napojit na slider  (UpdateSlider)
                // 3/ Druhy TMPro psat co je aktualni target (hezky pojmenovat)
                // 4/ UIManager jen pro UI, GameManager jen pro hru 
            }
        }
    }
}
