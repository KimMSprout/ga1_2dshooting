using Unity.Mathematics;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private GameObject _boomPrefab;
    [SerializeField] private Transform _boomSpawnPoint;
    // [SerializeField] private int _damage = 9999999;

    private float _coolTime = 10f;
    private float _coolTimer = 10f;

    void Update()
    {
        _coolTimer += Time.deltaTime;

        if (_coolTimer >= _coolTime && (Input.GetKeyDown(KeyCode.B)))
        {
            _coolTimer = 0f;
            Instantiate(_boomPrefab, _boomSpawnPoint.position, _boomSpawnPoint.rotation);
        }
    }
}