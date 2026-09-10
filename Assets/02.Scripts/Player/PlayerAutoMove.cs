using System;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    private GameObject[] _enemyPrefabs;
    private bool[] _isModeOn = new bool[3];
    private int _modeIndex = 0;

    private Player _player;
    private Transform _playerTransform;

    private Vector2 _direction;
    private Vector2 _goalVector;

    void Start()
    {
        _player = GetComponent<Player>();
        _playerTransform = GetComponent<Transform>();

        float randomX = UnityEngine.Random.Range(PlayerMove._borderLeft + 1f, PlayerMove._borderRight - 1f);
        float randomY = UnityEngine.Random.Range(PlayerMove._borderUnder + 1f, PlayerMove._borderUp - 1f);

        _goalVector = new Vector2(randomX, randomY);
    }

    void Update()
    {
        ModeSwitch();

        switch (_modeIndex)
        {
            case 0:
                MoveRandom();
                break;
            case 1:
                break;
            case 2:
                break;
            default:

                break;
        }

        Move();
    }

    private void Move()
    {
        _direction = ((Vector3)_goalVector - transform.position).normalized;

        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }

    private void ModeSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2번 키 입력!");
            _isModeOn[_modeIndex] = false;
            _modeIndex = 0;
            _isModeOn[_modeIndex] = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _isModeOn[_modeIndex] = false;
            _modeIndex = 1;
            _isModeOn[_modeIndex] = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _isModeOn[_modeIndex] = false;
            _modeIndex = 2;
            _isModeOn[_modeIndex] = true;
        }
    }

    private void MoveRandom()
    {
        if ((int)transform.position.x == (int)_goalVector.x && (int)transform.position.y == (int)_goalVector.y)
        {
            float randomX = UnityEngine.Random.Range(PlayerMove._borderLeft, PlayerMove._borderRight);
            float randomY = UnityEngine.Random.Range(PlayerMove._borderUnder, PlayerMove._borderUp);

            _goalVector = new Vector2(randomX, randomY);
        }
    }
}