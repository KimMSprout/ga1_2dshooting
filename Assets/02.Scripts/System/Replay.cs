using UnityEngine;
using System.Collections.Generic;

public class Replay : MonoBehaviour
{
    private void Start()
    {
        // _ICommand.Save(transform);
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     int length = _ICommand.GetLength();
        //     Debug.Log("R");
        //     Debug.Log(length);
        //     for(int i = 0; i < length; i++)
        //     {
        //         Transform nextTransform = _ICommand.Execute();
        //         Vector3 nextDirection = nextTransform.position;
        //         transform.position = new Vector2(nextTransform.position.x, nextTransform.position.y);
        //     }
        //     
        // }
        // deltaTime : 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS(밀리세컨즈)로 반환

        // 새로운 위치 = 현재 위치 + (방향 * 속력 * 시간)
        // transform.position += new Vector2(transform.position + (Vector3)direction * Speed * Time.deltaTime);   
    }
}

public class Command
{
    private Queue<Transform> _command = new Queue<Transform>();

    public void Save(Transform transform)
    {
        _command.Enqueue(transform);
    }

    public Transform Execute()
    {
        return _command.Dequeue();
    }

    public int GetLength()
    {
        return _command.Count;
    }
}