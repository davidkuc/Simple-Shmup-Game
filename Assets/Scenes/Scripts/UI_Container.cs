using System;
using UnityEngine;

public abstract class UI_Container : MonoBehaviour
{
    private GameObject container;
    private GameObject canvas;

    protected GameObject Container => container;

    protected GameObject Canvas => canvas; 

    protected virtual void Awake()
    {
        canvas = transform.Find("canvas").gameObject;
        container = Canvas.transform.Find("container").gameObject;
    }

    public bool ToggleContainer(bool active)
    {
        Container.SetActive(active);
        return Container.activeInHierarchy;
    }
}
