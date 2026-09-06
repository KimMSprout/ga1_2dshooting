using System;
using UnityEngine;

enum TYPE
{
    SpeedUp,
    HealthUp,
    AttackSpeedUp,
}

public class Item : MonoBehaviour
{
    [SerializeField] private TYPE _type;
    
    private GameObject _player;
    private Vector2 _direction;
    private float _moveSpeed = 3f;

    private float _spawnCooltime = 3f;
    private float _spawnTimer = 0f;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
        {
            return;
        }    
        _direction = _player.transform.position.normalized;
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        switch (_type)
        {
            case TYPE.SpeedUp:
                other.gameObject.GetComponent<PlayerMove>().SpeedUp();
                break;
            case TYPE.HealthUp:
                other.gameObject.GetComponent<Player>().HealthUp();
                break;
            case TYPE.AttackSpeedUp:
                other.gameObject.GetComponent<PlayerFire>().AttackSpeedUp();
                break;
        }
        Destroy(this.gameObject);
    }
}
