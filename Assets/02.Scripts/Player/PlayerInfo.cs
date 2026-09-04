using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private int _health;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            OnDamaged(enemy);
        }
    }

    private void OnDamaged(Enemy enemy)
    {
        _health -= enemy.damage;
        Destroy(enemy.gameObject);
        if (_health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}