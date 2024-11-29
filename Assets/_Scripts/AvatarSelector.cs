using System;
using UnityEngine;
public class AvatarSelector : MonoBehaviour
{
    public int SelectedAvatar = 0;
    public event Action OnAvatarChanged;
    public void SetAvatarSelector(int avatar)
    {
        SelectedAvatar = avatar;
        OnAvatarChanged?.Invoke();
    }
}
