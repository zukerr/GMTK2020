using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PagePanel : MonoBehaviour
{
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

    public void StartPage()
    {
        OnStart?.Invoke();
    }
    public void EndPage()
    {
        OnEnd?.Invoke();
    }

}
