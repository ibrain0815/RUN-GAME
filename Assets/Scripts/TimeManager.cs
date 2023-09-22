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


    IEnumerator TimeUpdate()  //�ڸ�ƾ �Լ�
    {
        while (true)
        {
            currentTime += Time.deltaTime;
            float sec = currentTime % 60; //�ʸ� 60���� ���� ������
            int min = (int)currentTime / 60; //�� = 60���� ���� ��
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
