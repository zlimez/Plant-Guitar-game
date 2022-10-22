using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game Event")]
public class GameEvent : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void TriggerEvent() {
        Debug.Log(this.name + " triggered");

        for (int i = 0; i < listeners.Count; i++) {
            Debug.Log(listeners[i].gameObject.name);
            listeners[i].OnEventTriggered();
        }
    }

    public void AddListener(EventListener listener) {
        listeners.Add(listener);
    }

    public void RemoveListener(EventListener listener) {
        listeners.Remove(listener);
    }
}
