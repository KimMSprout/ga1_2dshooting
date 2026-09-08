using UnityEngine;
using UnityEngine.Video;

public class Boom : MonoBehaviour
{
    [SerializeField] private int _damage = 9999999;
    private float _boomExistTime = 3f;
    private float _boomExistTimer = 0f;

    void Update()
    {
        _boomExistTimer += Time.deltaTime;

        if (_boomExistTimer >= _boomExistTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("폭탄과의 충돌");
        if (!other.CompareTag("Enemy")) return;

        other.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
    }
}