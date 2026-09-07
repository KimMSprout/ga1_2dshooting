using System;
using UnityEngine;
using Random = System.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed = 5;
    [SerializeField] private Item[] _items;

    public int damage = 10;

    protected abstract void Move();

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            SpawnItem();

            Destroy(this.gameObject);
        }
    }

    private void SpawnItem()
    {
        int random = UnityEngine.Random.Range(1, 100 + 1);

        if (random <= 30)
        {
            int randomItem = UnityEngine.Random.Range(0, 3);
            Item item = Instantiate(_items[randomItem], transform.position,
                transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        player.TakeDamage(damage);

        Destroy(this.gameObject);
    }
}