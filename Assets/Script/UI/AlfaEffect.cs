using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlfaEffect : MonoBehaviour
{
    float Step = 0.0f;
    Action action = null;

    bool isStart = false;

    [SerializeField]
    AlfaObject[] colors = null;

    float alfa = 1.0f;

    public void StartAffect(float _step, Action nextMetod)
    {
        alfa = 1.0f;
        Step = _step;
        action = nextMetod;
        isStart = true;
    }

    public void StartAffect(float _step)
    {
        alfa = 0.0f;
        Step = _step;
        isStart = true;
    }

    private void FixedUpdate()
    {
        if (isStart)
        {
            alfa += Step * Time.deltaTime;
            if (alfa <= 0.0) alfa = 0;
            if (alfa >= 1.0f) alfa = 1.0f;

            for(int i = 0; i < colors.Length; i++)
            {
                colors[i].ChangeColor(alfa);
            }
            if(alfa == 0.0f || alfa == 1.0f)
            {
                isStart = false;
                if (action != null) action();
                action = null;
            }
        }
    }
}
