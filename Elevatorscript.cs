using UnityEngine;

public class Elevatorscript : MonoBehaviour
{
    Vector3 positionA;
    Vector3 positionB;
    Vector3 target;
    GameObject elevator;
    bool move = false;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        positionA = elevator.transform.position;
        positionB = elevator.transform.position + new Vector3(0, 6, 0);
        
        
        
        ChnagePosition();
    }

    void ChnagePosition()
    {
        if (elevator.transform.position == positionA)
        {
            target = positionB;
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            target = positionA;
            GetComponent<Renderer>().material.color = Color.red;
        }
        move = true;
    }

    private void FixedUpdate()
    {
        if (move) 
        {
            if (target != elevator.transform.position)
            {
                elevator.transform.position = Vector3.MoveTowards(elevator.transform.position,
                    target, 1);
            }

            if (target == elevator.transform.position)
            {
                move = false;
            }
        }
    }
}
