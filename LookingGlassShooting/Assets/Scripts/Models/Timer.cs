using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float CountTime = 60.0f;
    [SerializeField]
    public bool IsEnabled = false;

    public UnityEvent onTimeUp = new UnityEvent();

    void Start()
    {
    }

    void Update()
    {
        if (IsEnabled)
        {
            CountTime -= Time.deltaTime;
        }

        if (CountTime < 0)
        {
            TimerStop();
            CountTime = 0;
            onTimeUp.Invoke();
        }
    }

    public void TimerSet(int time)
    {
        CountTime = (float)time;
    }

    public void TimerStart()
    {
        IsEnabled = true;
    }

    public void TimerStop()
    {
        IsEnabled = false;
    }
}
