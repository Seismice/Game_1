using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalEventManager
{
    public static Action OnUIManager;
    public static void ShowUIManager()
    {
        if (OnUIManager != null) OnUIManager.Invoke();
    }
}
