using UnityEngine;

public class EnemyDirectPlayer : Enemy
{
    public Transform player;

    void Start()
    {
        Vector2 direction = player.transform.position.normalized;
        SetDirection(direction);
    }
}