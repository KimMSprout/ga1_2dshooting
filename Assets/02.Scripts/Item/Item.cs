using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private TYPE _type;
    [SerializeField] private Transform _bezianPoint;

    private GameObject _player;
    private Vector2 _direction;
    private float _moveSpeed = 3f;

    private float _spawnCooltime = 3f;
    private float _spawnTimer = 0f;

    private Vector3 _startPosition;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
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
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
        // Vector3 p1 = Vector3.Lerp(transform.position, bezianPoint.position, time);
        // transform.position = Vector3.Lerp(p1, _player.transform.position, time);
        //
        // time += Time.deltaTime / 1.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        switch (_type)
        {
            case TYPE.SpeedUp:
                other.gameObject.GetComponent<PlayerMove>().SpeedUp(5f);
                break;
            case TYPE.HealthUp:
                other.gameObject.GetComponent<Player>().HealthUp(30);
                break;
            case TYPE.AttackSpeedUp:
                other.gameObject.GetComponent<PlayerFire>().AttackSpeedUp(-0.1f);
                break;
        }

        Destroy(this.gameObject);
    }
}