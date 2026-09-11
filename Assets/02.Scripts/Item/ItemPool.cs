using UnityEngine;
using System;

public class ItemPool : MonoBehaviour
{
    private static ItemPool _instance;
    public static ItemPool Instance => _instance;

    private int _poolSize = 50;
    [SerializeField] private Item[] _itemPrefabs;
    private Item[,] _pool;

    private int _itemCount = System.Enum.GetValues(typeof(ItemType)).Length;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this;
        _pool = new Item[_itemCount, _poolSize];

        for (int i = 0; i < _itemCount; i++)
        {
            for (int j = 0; j < _poolSize; j++)
            {
                Item item = Instantiate(_itemPrefabs[i], gameObject.transform);
                item.gameObject.SetActive(false);
                _pool[i, j] = item;
            }
        }
    }

    public Item GetItem(ItemType itemType)
    {
        for (int i = 0; i < _itemCount; i++)
        {
            if (_pool[i, 0].Type != itemType)
            {
                continue;
            }

            for (int j = 0; j < _poolSize; j++)
            {
                Item item = _pool[i, j];
                if (item.Type != itemType)
                {
                    continue;
                }

                if (item.gameObject.activeSelf == false)
                {
                    item.gameObject.SetActive(true);
                    return item;
                }
            }
        }

        return null;
    }
}