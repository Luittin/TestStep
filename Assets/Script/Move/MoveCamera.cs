using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Range(0.0f, 1.0f), SerializeField]
    float Speed = 0.2f;

    Vector3 target = Vector3.zero;
    bool isMoveDown = false;

    Vector3 targetMenuPos = Vector3.zero;
    bool isMoveVision = false;

    Vector3 position = Vector3.zero;
    Quaternion rotation = Quaternion.identity;

    private void Awake()
    {
        position = transform.position;
        rotation = transform.localRotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoveDown && transform.position.y <= target.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
        else if (transform.position.y >= target.y) isMoveDown = false;

        if(isMoveVision)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMenuPos, Speed * Time.deltaTime);
            if (transform.position == targetMenuPos) isMoveVision = false;
        }
        
    }

    public void AddTargetPosition(float _add)
    {
        target.y += _add;
        isMoveDown = true;
    }

    public void VisionCamera(int count)
    {
        isMoveDown = false;

        int k = (int)(count / 10);
        targetMenuPos.x = transform.position.x + (0.4f * k);
        targetMenuPos.y = transform.position.y;
        targetMenuPos.z = transform.position.z - (0.4f * k);
        isMoveVision = true;
    }

    public void RestartCamera()
    {
        targetMenuPos = Vector3.zero;
        isMoveVision = false;
        isMoveDown = false;        
        transform.position = position;
        target = transform.position;
        transform.localRotation = rotation;
    }
}
