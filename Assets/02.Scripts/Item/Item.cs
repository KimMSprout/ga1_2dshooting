using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private TYPE _type;
    [SerializeField] private Transform _bezianPoint;

    private Player _player;
    private Vector2 _direction;
    private const float MoveSpeed = 3f;

    private float _spawnCooltime = 3f;
    private float _spawnTimer = 0f;

    private Vector3 _startPosition;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (_player == null)
        {
            return;
        }

        _direction = (_player.transform.position - transform.position).normalized;
        // float bezianY = (_player.transform.position - transform.position).y / 2;
        //
        // float randomX = UnityEngine.Random.Range(-5f, 5f);
        // Instantiate(bezianPoint, new Vector2(randomX, bezianY),
        //     transform.rotation);
        //
        // _startPosition = transform.position;
    }

    void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer <= _spawnCooltime)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
        // Vector3 p1 = Vector3.Lerp(transform.position, bezianPoint.position, time);
        // transform.position = Vector3.Lerp(p1, _player.transform.position, time);
        //
        // time += Time.deltaTime / 1.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        // 심화 과제 1. 퍼사드 패턴 (패턴 : 객체지향에서 자주 일어나는 설계 문제를 잘 풀어내도록 경험에 의해 정리해 놓은 공식같은 거)
        // 심화 과제 2. 조합 패턴

        switch (_type)
        {
            case TYPE.SpeedUp:
                _player.GetComponent<PlayerMove>().SpeedUp(5f);
                break;
            case TYPE.HealthUp:
                _player.gameObject.GetComponent<Player>().HealthUp(30);
                break;
            case TYPE.AttackSpeedUp:
                _player.gameObject.GetComponent<PlayerFire>().AttackSpeedUp(0.1f);
                break;
        }

        Destroy(this.gameObject);
    }
}