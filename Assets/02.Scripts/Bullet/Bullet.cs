using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _speed;
    public int Damage;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    // 트리거 관련 이벤트
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌 발생!!");

        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            // 응집도는 높이고, 결합도는 낮춰라
            // 결합도란 묻는거... 매번 묻는거.. (너(객체) 체력 많아?
            enemy.TakeDamage(Damage);

            Destroy(this.gameObject);
        }
    }


    // 충돌 관련 이벤트
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("충돌 발생!!");
    //
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //
    //         // 응집도는 높이고, 결합도는 낮춰라
    //         // 결합도란 묻는거... 매번 묻는거.. (너(객체) 체력 많아?
    //         enemy.TakeDamage(Damage);
    //
    //         Destroy(this.gameObject);
    //     }
    // }
    //
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     Debug.Log("충돌 중!!");
    // }
    //
    // // 매개변수 collision은 충돌한 물체의 Game Object를 반환
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     Debug.Log("충돌 종료!!");
    // }
}