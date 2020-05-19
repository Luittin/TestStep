using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockResearch : MonoBehaviour
{
    public Action<GameObject> action = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.name == "Tower")
        {
            action(gameObject);
        }
        Destroy(GetComponent<BlockResearch>());
    }
}
