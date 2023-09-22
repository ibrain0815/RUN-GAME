using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "statusData")]//메뉴 맨 위로
//[CreateAssetMenu(fileName = "statusData", menuName = "ScripableObj/statusData", order = int.MaxValue)]//메뉴 맨 밑으로
//[CreateAssetMenu(fileName ="statusData",menuName = "ScriptableObject/statusData",order = int.MaxValue)]
public class RunnerData : ScriptableObject //유니티 스크립트 메뉴 추가 클래스 (데이터 저장용)
{
    public string runnerName;
    public Sprite runnerImage;
    public float accel;
    public float startSpd;
    public float maxSpd;


}
