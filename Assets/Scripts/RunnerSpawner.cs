using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public List<RunnerData> runnerDatas = new List<RunnerData>();
    public GameObject[] RunnerPrefabs; //ũ�Ⱑ ������ �ִ°��� �迭 , �߰� ������ ���Ѱ��� ����Ʈ
    public Transform spawnPos;
    public bool[] runnerIndexArray;  //���ʰ� Ȱ��ȭ �Ǿ��ִ� ���� Ȯ�� �迭
    public List<GameObject> runnerPortraits; //�ʻ�ȭ ����Ʈ
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
            spawnPos.position + new Vector3(2 * runnerObjects.Count, 0, 0), Quaternion.identity, transform); //ĳ���� X���� 2�� ���� ��ġ ��ġ

        newRunner.name = newRunner.GetComponent<RunerControl>().RunnerData.runnerName;
        //������ �ν��Ͻ� �̸� ����
        runnerObjects.Add(newRunner);
        runnerDatas.Add(newRunner.GetComponent<RunerControl>().RunnerData);
        return newRunner; //���� ������Ʈ ����
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
            runnerObjects[i].transform.rotation = Quaternion.identity; //ĳ���� ���� ���� ȸ��
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
