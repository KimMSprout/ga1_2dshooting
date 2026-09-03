using UnityEngine;

public class SubBulletMove : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}