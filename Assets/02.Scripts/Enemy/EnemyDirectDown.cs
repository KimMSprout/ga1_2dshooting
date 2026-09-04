using UnityEngine;

public class EnemyDirectDown : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    void Start()
    {
        Vector2 direction = Vector2.down;
        _direction = direction;
    }

    public void Update()
    {
        Move();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}