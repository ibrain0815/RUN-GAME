using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingBoard: MonoBehaviour
{
    public GameObject rankingPrefab;

    private void OnEnable()
    {
        if (GameManager.Instance == null) return;

        for(int i = 0; i < GameManager.Instance.goalList.Count; i++)
        {
            var prefab = Instantiate(rankingPrefab, transform);
            prefab.transform.GetChild(0).GetComponent<Text>().text = $"{i + 1}"; //��ŷ
            prefab.transform.GetChild(1).GetComponent<Image>().sprite
            = GameManager.Instance.goalList[i].GetComponent<RunerControl>().RunnerData.runnerImage; //ĳ���� �̹���
            prefab.transform.GetChild(2).GetComponent<Text>().text
            = GameManager.Instance.goalList[i].name; //ĳ���� �̸�
            prefab.transform.GetChild(3).GetComponent<Text>().text
            = GameManager.Instance.timeList[i]; //���� �ð�
        }
    }

    private void OnDisable()
    {
        foreach(Transform p in transform)
        {
            Destroy(p.gameObject);  //��ŷ ��� �ʱ�ȭ 
        }
    }
}
