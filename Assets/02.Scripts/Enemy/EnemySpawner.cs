using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval = 3f;

    private float _timer;

    // - 생성할 프리팹
    [SerializeField] private Enemy[] _enemyPrefabs;

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

        // Todo : Scriptable Object를 사용해서 리팩토링
        // 이유 1: 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알 수가 없음
        // 이유 2: 각 에너미 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵다.
        switch (spawnEnemyType)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                enemy = Instantiate(_enemyPrefabs[0]);
                break;
            case 6:
            case 7:
            case 8:
                enemy = Instantiate(_enemyPrefabs[1]);
                break;
            case 9:
            case 10:
                enemy = Instantiate(_enemyPrefabs[2]);
                break;
        }

        enemy.transform.position = transform.position;
    }
}