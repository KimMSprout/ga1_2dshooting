using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public float MoveSpeed;

    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public virtual void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
    }
}