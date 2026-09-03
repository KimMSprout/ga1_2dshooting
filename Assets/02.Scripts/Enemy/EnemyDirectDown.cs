using UnityEngine;

public class EnemyDirectDown : Enemy
{
    void Start()
    {
        Vector2 direction = Vector2.down;
        SetDirection(direction);
    }
}