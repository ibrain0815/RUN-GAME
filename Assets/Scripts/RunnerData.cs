using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "statusData")]//�޴� �� ����
//[CreateAssetMenu(fileName = "statusData", menuName = "ScripableObj/statusData", order = int.MaxValue)]//�޴� �� ������
//[CreateAssetMenu(fileName ="statusData",menuName = "ScriptableObject/statusData",order = int.MaxValue)]
public class RunnerData : ScriptableObject //����Ƽ ��ũ��Ʈ �޴� �߰� Ŭ���� (������ �����)
{
    public string runnerName;
    public Sprite runnerImage;
    public float accel;
    public float startSpd;
    public float maxSpd;


}
