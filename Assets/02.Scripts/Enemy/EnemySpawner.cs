using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval = 3f;

    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;
    [SerializeField] private EnemyBalanceDataTableSO _enemyDataTable;

    private float _timer;

    private void Start()
    {
    }

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
        // 가중치 랜덤 선택
        // 각 아이템에 가중치를 부여하고, 가중치가 클수록 높은 확률로 선택되도록 하는 방식

        // 1. 추첨할 수 있는 모든 가중치를 더한다.
        int totalWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        int randomWeight = Random.Range(0, totalWeight);

        int cumulativeWeight = 0;

        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight;

            if (randomWeight < cumulativeWeight)
            {
                Enemy enemy = EnemyPool.Instance.GetEnemy(data.EnemyPrefab.gameObject.GetComponent<Enemy>().Type);
                enemy.transform.position = transform.position;
                enemy.GetComponent<Enemy>().SetHealthBalance(GetHealthMultiplier());
                break;
            }
        }
    }

    public float GetHealthMultiplier()
    {
        // TODO: 기획자에게 물어보기
        int bestScore = ScoreManager.Instance.BestScore;
        float multiplier = 1f;

        EnemyBalanceData[] _enemyBalanceData = _enemyDataTable.Datas;


        for (int i = 0; i < _enemyBalanceData.Length; i++)
        {
            if (bestScore > _enemyBalanceData[i].RequiredScore)
            {
                multiplier = _enemyBalanceData[i].HealthMultiplier;
            }
            else
            {
                break;
            }
        }

        return multiplier;
    }
}