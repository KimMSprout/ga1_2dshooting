using System;
using UnityEngine;
using Random = System.Random;

public abstract class Enemy : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _damagedaudioSource;

    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed = 5;
    [SerializeField] private Item[] _items;
    [SerializeField] private GameObject _deathEffectPrefab;


    public int damage = 10;

    //TODO: 에너미가 공격 당할 때 피격 효과음 추가

    protected abstract void Move();

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _damagedaudioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _animator.SetTrigger("isHit");
        if (_health <= 0)
        {
            SpawnItem();
            SpawnDeathEffect();

            ScoreManager.Instance.AddScore(100);

            Destroy(this.gameObject);
        }

        _damagedaudioSource.Play();
    }

    void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    // Todo : Scriptable Object를 사용해서 리팩토링
    // 이유 1: 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알 수가 없음
    // 이유 2: 각 에너미 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵다.

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