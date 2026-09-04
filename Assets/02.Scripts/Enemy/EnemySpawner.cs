using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval = 3f;

    private float _timer;

    // - 생성할 프리팹
    [SerializeField] private Enemy _enemyDirectDownPrefab;
    [SerializeField] private Enemy _enemyDirectPlayerPrefab;
    [SerializeField] private Enemy _enemyFollowPlayerPrefab;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0;

            _spawnInterval = Random.Range(1f, 3f); // float: 1 ~ 3

            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnEnemyType = Random.Range(1, 11);
        Enemy enemy = null;
        switch (spawnEnemyType)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                enemy = Instantiate(_enemyDirectDownPrefab);
                break;
            case 6:
            case 7:
            case 8:
                enemy = Instantiate(_enemyDirectPlayerPrefab);
                break;
            case 9:
            case 10:
                enemy = Instantiate(_enemyFollowPlayerPrefab);
                break;
        }
        enemy.transform.position = transform.position;
    }
}