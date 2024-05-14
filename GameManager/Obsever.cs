using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Observer : MonoBehaviour
{
    private static Observer instance = null;
    public static Observer Instance => instance;
    private Dictionary<string,Action> listeners = new Dictionary<string, Action>();
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null && instance.GetInstanceID() != this.GetInstanceID()) Destroy(this);
    }
    public bool AddListaner(string key, Action action)
    {
        if(!listeners.ContainsKey(key))
        {
            if(listeners.TryAdd(key, action)) return true;
            Debug.LogError("don't add key");
            return false;
        }
        return false;
    }
    public void Notify(string key)
    {
        if(listeners.ContainsKey(key))
        {
            listeners[key]?.Invoke();
            return;
        }

        Debug.LogError($"don't have key {key}");
    }
    public void removeListener(string key)
    {
        if (listeners.ContainsKey(key)) listeners.Remove(key);
        else Debug.LogError($"don't have key {key}");
    }
}
