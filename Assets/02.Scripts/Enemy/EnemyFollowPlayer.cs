using UnityEngine;

public class EnemyFollowPlayer : Enemy
{
    public Transform player;

    public override void Update()
    {
        Vector2 direction = player.transform.position.normalized;
        SetDirection(direction);
        Move();
    }
}