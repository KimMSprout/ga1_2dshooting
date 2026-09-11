using System;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private static EnemyPool _instance;
    public static EnemyPool Instance => _instance;

    private int _poolSize = 50;
    private int _enemyCount = System.Enum.GetValues(typeof(EnemyType)).Length;

    [SerializeField] private Enemy[] _enemyPrefabs;
    private Enemy[,] _pool = null;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this;

        _pool = new Enemy[_enemyCount, _poolSize];

        for (int i = 0; i < _enemyCount; i++)
        {
            for (int j = 0; j < _poolSize; j++)
            {
                Enemy enemy = Instantiate(_enemyPrefabs[i], gameObject.transform);
                enemy.gameObject.SetActive(false);
                _pool[i, j] = enemy;
            }
        }
    }

    public Enemy GetEnemy(EnemyType type)
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            if (_pool[i, 0].gameObject.GetComponent<Enemy>().Type != type)
            {
                continue;
            }

            for (int j = 0; j < _poolSize; j++)
            {
                Enemy enemy = _pool[i, j];

                if (enemy.gameObject.activeSelf == false)
                {
                    enemy.gameObject.SetActive(true);
                    return enemy;
                }
            }
        }

        return null;
    }
}