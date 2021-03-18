using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private ScreenBase[] screens;

    void Awake()
    {
        App.screenManager = this;
        screens = GetComponentsInChildren<ScreenBase>(true);
    }

    public void Show<T>()
    {
        ScreenBase screen = GetScreen<T>();

        if(screen != null)
        {
            screen.Show();
        }
        else
        {
            Debug.LogError($"Screen { typeof(T) } not found");
        }
    }

    public void Hide<T>()
    {
        ScreenBase screen = GetScreen<T>();

        if(screen != null)
        {
            screen.Hide();
        }
        else
        {
            Debug.LogError($"Screen { typeof(T) } not found");
        }
    }

    private ScreenBase GetScreen<T>()
    {
        foreach(ScreenBase screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                return screen;
            }
        }
        return null;
    }
}
