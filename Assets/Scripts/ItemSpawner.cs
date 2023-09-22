using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    Collider rangeCol; //������ ������
    public GameObject[] items; //������ų ������ �迭

    private void Awake()
    {
        rangeCol = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        Invoke("AutoSpawn", 1f);
    }

    public void AutoSpawn()
    {
        if (GameManager.Instance.isStart)
        {
            for(int i = 0; i<5; i++)
            {
                SpawnItem();
            }
        }
        Invoke("AutoSpawn", 5f); //5�� �Ŀ� AutoSpawn �Լ� ���� 
    }

    Vector3 RandomPos()  // �������� ������ġ�� �����ϴ� �Լ�
    {
        float rangeX = rangeCol.bounds.size.x;
        float rangeY = rangeCol.bounds.size.y;
        float rangeZ = rangeCol.bounds.size.z;
        rangeX = Random.Range((rangeX / 2) * -1, rangeX / 2);
        rangeY = Random.Range((rangeY / 2) * -1, rangeY / 2);
        rangeZ = Random.Range((rangeZ / 2) * -1, rangeZ / 2);

        Vector3 pos = new Vector3(rangeX,rangeY,rangeZ) + transform.position;
        return pos;
    }

    public void SpawnItem() //������ ȣ�� (�ڵ�,����)
    {
        var item = Instantiate(items[Random.Range(0,items.Length)], RandomPos(),Quaternion.identity,transform);
    }


}
