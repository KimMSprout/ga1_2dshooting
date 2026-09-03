using UnityEngine;

public class EnemyFollowPlayer : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        Vector2 direction = _player.transform.position.normalized;
        _direction = direction;
        Move();
    }

    protected override void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}