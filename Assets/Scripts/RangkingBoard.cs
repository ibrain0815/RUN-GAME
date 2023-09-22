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
            prefab.transform.GetChild(0).GetComponent<Text>().text = $"{i + 1}"; //랭킹
            prefab.transform.GetChild(1).GetComponent<Image>().sprite
            = GameManager.Instance.goalList[i].GetComponent<RunerControl>().RunnerData.runnerImage; //캐릭터 이미지
            prefab.transform.GetChild(2).GetComponent<Text>().text
            = GameManager.Instance.goalList[i].name; //캐릭터 이름
            prefab.transform.GetChild(3).GetComponent<Text>().text
            = GameManager.Instance.timeList[i]; //들어온 시간
        }
    }

    private void OnDisable()
    {
        foreach(Transform p in transform)
        {
            Destroy(p.gameObject);  //랭킹 기록 초기화 
        }
    }
}
