using UnityEngine;

public class PlatformStick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SetParent(transform);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.transform.SetParent(null);
    }
}

