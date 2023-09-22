using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!GameManager.Instance.goalList.Contains(other.gameObject))
        {
            other.GetComponent<RunerControl>().rb.velocity = Vector3.zero;
            GameManager.Instance.goalList.Add(other.gameObject);
            GameManager.Instance.timeList.Add(FindAnyObjectByType<TimeManager>().timeText);
            other.GetComponent<RunerControl>().StopRun();


            if(GameManager.Instance.runners.Count == GameManager.Instance.goalList.Count)  //모든 골인한것 체크
            {
                GameManager.Instance.EndRun();
                //GameManager.Instance.Award();
            }
        }




    }
}

