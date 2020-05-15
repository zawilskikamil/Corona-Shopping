using UnityEngine;

public class DeleteAfterDelay: MonoBehaviour
{
    public float delay = 5.0f;

    void Start()
    {
        Object.Destroy(gameObject, delay);
    }
}
