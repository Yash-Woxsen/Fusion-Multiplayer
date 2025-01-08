using UnityEngine;

[CreateAssetMenu(fileName = "SessionData", menuName = "Scriptable Objects/SessionData")]
public class SessionData : ScriptableObject
{
    public event System.Action isConnectedAndReadyEvent;

    public void RaiseEvent()
    {
        isConnectedAndReadyEvent?.Invoke();
    }
}
