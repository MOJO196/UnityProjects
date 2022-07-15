using UnityEngine;

public class OffScreenDestroy : MonoBehaviour
{
    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
