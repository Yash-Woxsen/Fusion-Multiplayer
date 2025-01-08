using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }
}
