using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFSM : MonoBehaviour
{
    public Transform target;
    public float chaseRange = 5;
    public float chaseSpeed = 5;

    public States curState;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            switch (curState)
            {
                case States.Init:
                    curState = States.Idle;
                    break;
                case States.Chase:
                    Chase();
                    break;
                case States.Idle:
                    Idle();
                    break;
            }
            yield return null;
        }
    }

    private void Idle()
    {
        if(Vector3.Distance(transform.position, target.position) <= chaseRange)
        {
            curState = States.Chase;
        }
    }
    public void Chase()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += direction * chaseSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) >= chaseRange)
        {
            curState = States.Chase;
        }
    }

    public enum States
    {
        Init,
        Idle,
        Chase
    }
   
}
