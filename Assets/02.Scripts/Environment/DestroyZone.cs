using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
        }

        else
        {
            Destroy(other.gameObject);
        }
    }
}