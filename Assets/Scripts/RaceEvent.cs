using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OneEventEnum
{
   OneSlow,OneFast,Nothing, AllSlow, AllFast, HalfSlow, HalfFast 
}

public class RaceEvent : MonoBehaviour
{

    public void CallRandomEvent()
    {
        OneEventEnum RandomEvent = (OneEventEnum)Random.Range(0, System.Enum.GetValues(typeof(OneEventEnum)).Length);
        Invoke(RandomEvent.ToString(), 0f); //같은 이름의 함수를 0초후에 바로 실행함.
    }

    public void AutoRandomEvent()
    {
        OneEventEnum RandomEvent = (OneEventEnum)Random.Range(0, System.Enum.GetValues(typeof(OneEventEnum)).Length);
        Invoke(RandomEvent.ToString(), 0f); //같은 이름의 함수를 0초후에 바로 실행함.
        if (GameManager.Instance.isStart)
        {
            Invoke("AutoRandomEvent", 2f);
        }

    }


    public void AllSlow()
    {
        foreach(var r in GameManager.Instance.runners)
        {
            r.GetComponent<RunerControl>().currentSpd /= 2;
        }
        print("All Slow!!");
    }
    public void AllFast()
    {
        foreach (var r in GameManager.Instance.runners)
        {
            r.GetComponent<RunerControl>().currentSpd *= 2;
        }
        print("All Fast!!");
    }

    public void HalfSlow()
    {
        List<GameObject> newList = new List<GameObject>(); //새로운 리스트
        newList.AddRange(GameManager.Instance.runners); //러너 목록 복사
        int half = newList.Count / 2; //러너의 절반 갯수 변수
        for(int i = 0; i < half; i++) //절반 갯수 만큼 for문
        {
            int rnd = Random.Range(0, newList.Count);
            newList[rnd].GetComponent<RunerControl>().currentSpd /= 2; //랜덤한 러너의 속도 변화
            newList.RemoveAt(rnd); //리스트에서 해당 랜덤한 러너 제거

        }
        print("Half Slow!!");
    }

    public void HalfFast()
    {
        List<GameObject> newList = new List<GameObject>(); //새로운 리스트
        newList.AddRange(GameManager.Instance.runners); //러너 목록 복사
        int half = newList.Count / 2; //러너의 절반 갯수 변수
        for (int i = 0; i < half; i++) //절반 갯수 만큼 for문
        {
            int rnd = Random.Range(0, newList.Count);
            newList[rnd].GetComponent<RunerControl>().currentSpd /= 2; //랜덤한 러너의 속도 변화
            newList.RemoveAt(rnd); //리스트에서 해당 랜덤한 러너 제거

        }
        print("Half Fast!!");
    }

    public void OneSlow()
    {
        var target = GameManager.Instance.runners[Random.Range(0, GameManager.Instance.runners.Count)];
        target.GetComponent<RunerControl>().currentSpd /= 2;
        print($"{ target.name}: Slow!!");
    }

    public void OneFast()
    {
        var target = GameManager.Instance.runners[Random.Range(0, GameManager.Instance.runners.Count)];
        target.GetComponent<RunerControl>().currentSpd *= 2;
        print($"{ target.name}: Fast!!");
    }

    public void Nothing()
    {
        print("Not Happened...");
    }
}
