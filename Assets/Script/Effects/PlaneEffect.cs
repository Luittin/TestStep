using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEffect : MonoBehaviour
{
    [Range(0.0f, 5.0f), SerializeField]
    float Speed = 0.25f;

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        float step = Speed * Time.deltaTime;
        scale.x += step;
        scale.z += step;
        transform.localScale = scale;
        if (scale.x >= 0.15f) Destroy(gameObject);
    }
}
