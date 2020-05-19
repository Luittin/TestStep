using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Range(0.0f, 10.0f), SerializeField]
    float Speed = 1.5f;

    Vector3 targetPosition = Vector3.zero;

    private void Awake()
    {
        NewTargetPosition();
    }

    private void Start()
    {
        Speed = 1.5f;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

        if (transform.position == targetPosition) NewTargetPosition();

        if (transform.position.y < -10.0f) Destroy(gameObject);
    }

    private void NewTargetPosition()
    {
        targetPosition = transform.position;

        if(Mathf.Abs(targetPosition.x) > Mathf.Abs(targetPosition.z))
            targetPosition.x *= -1;
        else
            targetPosition.z *= -1;
    }

    public bool StopBlock(Transform target)
    {
        float speedStep = Speed * Time.deltaTime;
        Speed = 0.0f;

        targetPosition = target.position;
        targetPosition.y = transform.position.y;

        Debug.Log(Mathf.Abs(Vector3.Distance(transform.position, targetPosition)) + "|||||" + speedStep);
        if(Mathf.Abs(Vector3.Distance(transform.position,targetPosition)) <= speedStep)
        {
            return true;
        }
        return false;
    }
}
