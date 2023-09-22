using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeUI;
    float currentTime;
    public string timeText;
    private void OnEnable()
    {
        currentTime = 0;
        StartCoroutine(TimeUpdate());
    }


    IEnumerator TimeUpdate()  //코르틴 함수
    {
        while (true)
        {
            currentTime += Time.deltaTime;
            float sec = currentTime % 60; //초를 60으로 나눈 나머지
            int min = (int)currentTime / 60; //분 = 60으로 나눈 몫
            timeText = $"{min:00}:{sec:00.00}";
            timeUI.text = timeText;
            yield return null;
            if (!GameManager.Instance.isStart) break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
