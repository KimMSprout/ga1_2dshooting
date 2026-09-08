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
        if (_player == null) return;

        Vector2 direction = _player.transform.position.normalized;
        _direction = direction;
        Move();
    }

    protected override void Move()
    {
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}