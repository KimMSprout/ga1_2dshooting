using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float Damage;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * Speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 발생!!");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.Health -= Damage;
            if (enemy.Health <= 0)
            {
                Destroy(collision.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("충돌 중!!");
    }

    // 매개변수 collision은 충돌한 물체의 Game Object를 반환
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("충돌 종료!!");
    }
}