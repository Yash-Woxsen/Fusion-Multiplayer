using UnityEngine;

public class UserNameLookAtCamera : MonoBehaviour
{
    public SessionData sessionData;
    public TMPro.TMP_Text nameText;
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
    void SetName()
    {
        nameText.text = sessionData.userName;
    }
    void Start()
    {
        SetName();
    }
}
