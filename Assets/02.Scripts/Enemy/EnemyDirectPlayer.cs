using UnityEngine;

public class EnemyDirectPlayer : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    void Start()
    {
        Vector2 direction = _player.transform.position.normalized;
        _direction = direction;
    }

    public void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Move();
    }

    protected override void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}