using System;
using UnityEngine;

/// <summary>
/// scriptableObject로 데이터 저장 전용 class
/// </summary>
public class InfoHandler : MonoBehaviour
{
    [SerializeField] private NPCSO so;
    public NPCSO SO { get { return so; }}

}