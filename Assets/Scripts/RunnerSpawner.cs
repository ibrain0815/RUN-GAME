using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public List<RunnerData> runnerDatas = new List<RunnerData>();
    public GameObject[] RunnerPrefabs; //크기가 정해져 있는것은 배열 , 추가 삭제가 는한것은 리스트
    public Transform spawnPos;
    public bool[] runnerIndexArray;  //러너가 활성화 되어있는 상태 확인 배열
    public List<GameObject> runnerPortraits; //초상화 리스트
    public List<GameObject> runnerObjects = new List<GameObject>(); 

    private void Awake()
    {
        for(int i = 0; i<RunnerPrefabs.Length; i++)
        {
            var runner = SpawnRunner(i);
            runner.SetActive(false);
        }
        runnerIndexArray = new bool[RunnerPrefabs.Length];
    }

    public GameObject SpawnRunner(int index)
    {
        var newRunner = Instantiate(RunnerPrefabs[index],
            spawnPos.position + new Vector3(2 * runnerObjects.Count, 0, 0), Quaternion.identity, transform); //캐릭터 X값에 2를 곱해 위치 배치

        newRunner.name = newRunner.GetComponent<RunerControl>().RunnerData.runnerName;
        //프리팹 인스턴스 이름 변경
        runnerObjects.Add(newRunner);
        runnerDatas.Add(newRunner.GetComponent<RunerControl>().RunnerData);
        return newRunner; //게임 오브젝트 리턴
    }

    public void ToggleSpawnIndexArray(int index)
    {
        runnerObjects[index].SetActive(!runnerObjects[index].activeInHierarchy);
        runnerIndexArray[index] = !runnerIndexArray[index];
        runnerPortraits[index].SetActive(!runnerPortraits[index].activeInHierarchy);
    }


    public void Restart()
    {
        for(int i = 0; i< runnerObjects.Count; i++)
        {
            runnerObjects[i].transform.position = spawnPos.position + new Vector3(2 * i, 0, 0);
            runnerObjects[i].transform.rotation = Quaternion.identity; //캐릭터 정면 방향 회전
            runnerObjects[i].SetActive(false);
            runnerIndexArray[i] = false;
            runnerPortraits[i].SetActive(false);
        }
    }

    public void AllToggle()
    {
        for (int i = 0; i < runnerObjects.Count; i++)
        {
            runnerObjects[i].gameObject.SetActive(true);
            runnerPortraits[i].gameObject.SetActive(true);
            runnerIndexArray[i] = true;
        }
    }

}
