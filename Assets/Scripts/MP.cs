using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MP : MonoBehaviour
{
    public float MaxMP;
    public float curMP;
    public Slider MPBar;

    void Start()
    {
        curMP = MaxMP;
        MPBar.maxValue = MaxMP; //slider의 MaxValue를 우리가 원하는 체력 최대치로 초기화
        MPBar.value = curMP; //slider의 value 값을 현재의 HP 값으로 초기화
    }

    void Update()
    {
        MPBar.value = curMP;
        curMP++;
        if (curMP > 100) curMP--;
    }
}