using UnityEngine;

public enum StatsChangeType
{
    Add = 0,
    Multiple,
    Override,
}

//데이터 폴더처럼 사용할 수 있게 만들어주는 Attribute
[System.Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;

    [Range(1, 100)] public int maxHealth;
    [Range(1, 100)] public float speed;
    public AttackSO attackSO;
}