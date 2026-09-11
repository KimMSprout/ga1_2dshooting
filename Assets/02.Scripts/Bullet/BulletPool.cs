using System;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;

    // 오브젝트 풀링이란: 오브젝트의 Pool(웅덩이: 창고)를 만들어 두고,
    // 그 창고 안에 게임 오브젝트를 미리 필요한 만큼 만들어두고,
    // 필요할 떄마다 꺼내서 사용하고 필요가 없으면 반환하는 식으로 (활성화/비활성화)
    // 메모리 할당과 해제를 최소화해서 성능 Up!;

    // 필요 속성
    [Header("총알 프리팹들")]
    [SerializeField] private Bullet[] _bulletPrefabs;

    [Header("풀 사이즈")]
    [SerializeField] private int _poolSize = 50;

    // 생성한 총알을 담아둘 풀
    private Bullet[,] _pool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this;

        _pool = new Bullet[_bulletPrefabs.Length, _poolSize];

        for (int i = 0; i < _bulletPrefabs.Length; i++)
        {
            Bullet bulletPrefab = _bulletPrefabs[i];
            for (int j = 0; j < _poolSize; j++)
            {
                Bullet bullet = Instantiate(bulletPrefab, this.gameObject.transform);
                bullet.gameObject.SetActive(false); // 당장 사용할 거 아니기에 비활성화
                _pool[i, j] = bullet;
            }
        }
    }

    public Bullet GetBullet(BulletType bulletType)
    {
        for (int i = 0; i < _pool.GetLength(0); i++)
        {
            if (_pool[i, 0].Type != bulletType)
            {
                continue;
            }

            for (int j = 0; j < _pool.GetLength(1); j++)
            {
                Bullet bullet = _pool[i, j];

                if (bullet.Type != bulletType)
                {
                    continue;
                }

                if (bullet.gameObject.activeSelf == false)
                {
                    bullet.gameObject.SetActive(true);
                    bullet.OnSpawn();
                    return bullet;
                }
            }
        }

        return null;
    }
}