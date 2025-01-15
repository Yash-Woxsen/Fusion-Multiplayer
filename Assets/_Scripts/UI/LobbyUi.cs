using Fusion;
using UnityEngine;

public class LobbyUi : MonoBehaviour
{
    public FusionBootstrap fusionBootstrap;

    public void SetRoomName(string roomName)
    {
        fusionBootstrap.DefaultRoomName = roomName;
    }

    public GameObject avatarPanel;
    public void TogglePanel()
    {
        avatarPanel.SetActive(!avatarPanel.activeSelf);
    }
}
