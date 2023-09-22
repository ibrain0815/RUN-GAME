using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //static 전역 변수 
    public List<GameObject> runners = new List<GameObject>();
    public List<GameObject> goalList = new List<GameObject>();
    public List<string> timeList = new List<string>();
    public GameObject SelectUI,playUI,rankingUI,RestartUI;
    public float topZ; //선두값

    public bool isStart;
    public CinemachineVirtualCamera camSelect,camGoal,camAward;
    public List<CinemachineVirtualCamera> vCamList = new List<CinemachineVirtualCamera>();
    public ItemSpawner itemSpawner;

    public Transform awardPos1, awardPos2, awardPos3;
    public GameObject[] items;
    public GameObject podium, trophy;
    public AudioSource itemSFX, winSFX, resultSFX; 


    private void Awake()
    {
        Instance = this;

    }

    public void EndRun()
    {
        isStart = false;
        playUI.SetActive(false);
        goalList[0].GetComponent<RunerControl>().Win();
        //camGoal.LookAt = goalList[0].transform;
        camGoal.Follow = goalList[0].transform;

        StartCoroutine(DelayRanking());
        StartCoroutine(DelayAward());

    }



    IEnumerator DelayRanking()  //랭킹 리스트 불러오기
    {
        camGoal.Priority = 50;
        yield return new WaitForSeconds(3);
        rankingUI.SetActive(true);

    }

    IEnumerator DelayAward() // 1,2,3등 시상대 이동 
    {
        yield return new WaitForSeconds(5);
        rankingUI.SetActive(false);
        resultSFX.Play();
        
        RestartUI.SetActive(true);
        podium.SetActive(true);

        if (goalList.Count == 1)
        {
            goalList[0].transform.position = awardPos1.transform.position;
            goalList[0].transform.rotation = awardPos1.transform.rotation;
        }
        else if (goalList.Count == 2)
        {
            goalList[0].transform.position = awardPos1.transform.position;
            goalList[0].transform.rotation = awardPos1.transform.rotation;
            goalList[1].transform.position = awardPos2.transform.position;
            goalList[1].transform.rotation = awardPos2.transform.rotation;
        }
        else if (goalList.Count > 2)
        {
            goalList[0].transform.position = awardPos1.transform.position;
            goalList[0].transform.rotation = awardPos1.transform.rotation;
            goalList[1].transform.position = awardPos2.transform.position;
            goalList[1].transform.rotation = awardPos2.transform.rotation;
            goalList[2].transform.position = awardPos3.transform.position;
            goalList[2].transform.rotation = awardPos3.transform.rotation;
        }


        // yield return new WaitForSeconds(1);
        camAward.Priority = 60;
        //camAward.Follow = goalList[0].transform;
         for(int i=0; i < goalList.Count ; i++)
        {
            goalList[i].GetComponent<RunerControl>().Win();
        }
        
        yield return new WaitForSeconds(3);
        
        trophy.SetActive(true);
        winSFX.Play();
    }






    void Start()
    {
        topZ = FindObjectOfType<RunnerSpawner>().spawnPos.transform.position.z;
        camSelect.Priority = 11;
        isStart = false;
        SelectUI.SetActive(true);
        playUI.SetActive(false);
        rankingUI.SetActive(false);
 
    }

    private void FixedUpdate()
    {
        
       if(isStart) CamTop();
    }

    void CamTop()
    {
        foreach(var r in runners)
        {
            if (!goalList.Contains(r))
            {
                if (r.transform.localPosition.z > topZ)
                {
                    vCamList[0].Follow = r.transform;
                    vCamList[1].Follow = r.transform;
                    topZ = r.transform.localPosition.z;
                }
            }
        }
    }
    public void StartRun()
    {
        topZ = FindAnyObjectByType<RunnerSpawner>().spawnPos.transform.position.z;
        runners.AddRange(GameObject.FindGameObjectsWithTag("Player"));//액티브된 오브젝트들만 찾아서 리스트에 추가
        if(runners.Count >0)
        {
            foreach(var runner in runners)
            {
                runner.GetComponent<RunerControl>().Run();
            }
            SelectUI.SetActive(false);
            playUI.SetActive(true);
            camSelect.Priority = 2;
            isStart = true;
            itemSpawner.gameObject.SetActive(true);
            StartCoroutine(CamCotrol());
            //GetComponent<RaceEvent>().AutoRandomEvent();
        }
    }


    IEnumerator CamCotrol()
    {
        while (isStart)
        {
                int rnd = Random.Range(0, vCamList.Count);
                vCamList[rnd].Priority = 13;
                yield return new WaitForSeconds(3f);
                vCamList[rnd].Priority = 10;
                yield return new WaitForSeconds(3f);

        }
    }

public void RestartBtn()
    {
        SelectUI.SetActive(true);
        playUI.SetActive(false);
        rankingUI.SetActive(false);
        
        camSelect.Priority = 15;
        camAward.Priority = 5;
        camGoal.Priority = 6;
        isStart = false;
        foreach(var runner in runners)
        {
            runner.GetComponent<RunerControl>().StopRun();
        }

        runners.Clear();
        goalList.Clear();
        timeList.Clear();
        FindObjectOfType<RunnerSpawner>().Restart();
        //RaceItem[] items = FindObjectsOfType<RaceItem>();
         items = GameObject.FindGameObjectsWithTag("item");
        Debug.Log(items.Length); 
        foreach(var item in items)
        {
            Destroy(item.gameObject);
        }

        itemSpawner.gameObject.SetActive(false);  //나와 있는 아이템 초기화 
        RestartUI.SetActive(false);
        podium.SetActive(false);
        trophy.SetActive(false);
    }


    
}
