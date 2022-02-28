using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class buttonController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent[] onClick;
    public UnityEvent[] onDown;
    public UnityEvent[] onHold;
    public UnityEvent[] onRelease;
    private bool isholding;
    private int i;

    public void Start()
    {
        isholding = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        for(i=0;i< onClick.Length;i++)
        {
            onClick[i].Invoke();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isholding = true;
        for(i=0;i< onDown.Length;i++)
        {
            onDown[i].Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isholding = false;
        for(i=0;i< onRelease.Length;i++)
        {
            onRelease[i].Invoke();
        }
    }

    public void Update()
    {
        if (isholding)
        {
            for(i=0;i< onHold.Length;i++)
            {
                onHold[i].Invoke();
            }
        }
    }
}
