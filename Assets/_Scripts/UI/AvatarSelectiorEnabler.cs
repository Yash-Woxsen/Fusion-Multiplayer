using UnityEngine;

namespace GCC.UI
{
    public class AvatarSelectiorEnabler : MonoBehaviour
    {
        public SessionData sessionData;
        public GameObject avatarSelectionPanel;
        public GameObject loadingScreen;
        void Start()
        {
            sessionData.isConnectedAndReadyEvent += EnableAvatarSelection;
        }
        void EnableAvatarSelection()
        {
            loadingScreen.SetActive(false);
            avatarSelectionPanel.SetActive(true);
        }
    }
}
