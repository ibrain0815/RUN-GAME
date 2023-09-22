using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    Collider rangeCol; //범위용 데이터
    public GameObject[] items; //스폰시킬 아이템 배열

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
        Invoke("AutoSpawn", 5f); //5초 후에 AutoSpawn 함수 실행 
    }

    Vector3 RandomPos()  // 아이템을 랜덤위치로 생성하는 함수
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

    public void SpawnItem() //아이템 호출 (자동,수동)
    {
        var item = Instantiate(items[Random.Range(0,items.Length)], RandomPos(),Quaternion.identity,transform);
    }


}
