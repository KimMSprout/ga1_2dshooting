using System;
using UnityEngine;

public class AwakeTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"[Awake] {gameObject.name}");
    }
}
