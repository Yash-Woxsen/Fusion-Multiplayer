using UnityEngine;
using TMPro;

public class SaveDataToSO : MonoBehaviour
{
    public SessionData sessionData;

    public TMP_InputField userName, serverCode;

    public void SaveData()
    {
        sessionData.userName = userName.text;
        sessionData.serverCode = serverCode.text;
    }
}
