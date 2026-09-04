using UnityEngine;

public class EnemyDirectPlayer : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    void Start()
    {
        // 1. 여기서 딱 한 번만 플레이어를 찾아서 캐싱해 (성능 최적화)
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player != null)
        {
            // 2. (플레이어 위치 - 내 위치)로 정확한 이동 방향을 계산해
            _direction = (_player.transform.position - transform.position).normalized;
        }
    }

    public void Update()
    {
        // 3. 무거운 Find 연산을 빼고 가볍게 Move만 호출해 (들여쓰기도 8칸으로 교정 완료)
        Move();
    }

    protected override void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}