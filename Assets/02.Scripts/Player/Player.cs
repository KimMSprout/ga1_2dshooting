using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    // - 데이터 은닉
    // - 메서드를 통한 상태 변경

    [SerializeField] private int _health = 100;
    [SerializeField] private GameObject _deathEffectPrefab;

    // 잘 설계된 클래스는
    // - 필드 (인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게 막고, 정상적으로 동작하는 메서드

    public int Health
    {
        set
        {
            if (value < 0) return;
            _health = value;
        }

        get { return _health; }
    }

    // 무결성 검사를 해야한다.
    // 무결성 : 잘못된 데이터가 들어가지 않게 하는 것
    // ex) 최대 체력보다 체력은 적어야 한다...
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            SpwanDeathEffect();
            Destroy(this.gameObject);
        }
    }

    public void HealthUp(int value)
    {
        _health += value;
    }

    void SpwanDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }
}