using UnityEngine;

public class OffScreenDestroy : MonoBehaviour
{
    void OnBecameInvisible() 
    {
        ObjectSpawner.instance.tiles--;
        Destroy(gameObject);
    }
}
