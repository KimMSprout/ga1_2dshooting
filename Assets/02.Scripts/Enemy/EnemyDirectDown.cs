using UnityEngine;

public class EnemyDirectDown : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = Vector2.down;
        _direction = direction;
    }

    public void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}