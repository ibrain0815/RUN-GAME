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
        Invoke(RandomEvent.ToString(), 0f); //���� �̸��� �Լ��� 0���Ŀ� �ٷ� ������.
    }

    public void AutoRandomEvent()
    {
        OneEventEnum RandomEvent = (OneEventEnum)Random.Range(0, System.Enum.GetValues(typeof(OneEventEnum)).Length);
        Invoke(RandomEvent.ToString(), 0f); //���� �̸��� �Լ��� 0���Ŀ� �ٷ� ������.
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
        List<GameObject> newList = new List<GameObject>(); //���ο� ����Ʈ
        newList.AddRange(GameManager.Instance.runners); //���� ��� ����
        int half = newList.Count / 2; //������ ���� ���� ����
        for(int i = 0; i < half; i++) //���� ���� ��ŭ for��
        {
            int rnd = Random.Range(0, newList.Count);
            newList[rnd].GetComponent<RunerControl>().currentSpd /= 2; //������ ������ �ӵ� ��ȭ
            newList.RemoveAt(rnd); //����Ʈ���� �ش� ������ ���� ����

        }
        print("Half Slow!!");
    }

    public void HalfFast()
    {
        List<GameObject> newList = new List<GameObject>(); //���ο� ����Ʈ
        newList.AddRange(GameManager.Instance.runners); //���� ��� ����
        int half = newList.Count / 2; //������ ���� ���� ����
        for (int i = 0; i < half; i++) //���� ���� ��ŭ for��
        {
            int rnd = Random.Range(0, newList.Count);
            newList[rnd].GetComponent<RunerControl>().currentSpd /= 2; //������ ������ �ӵ� ��ȭ
            newList.RemoveAt(rnd); //����Ʈ���� �ش� ������ ���� ����

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
