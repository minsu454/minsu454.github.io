using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public int level;
    public int cardMax;
    public float time;
    public BossType type;

    public Stage(int level, int cardMax, float Time, BossType type = BossType.None)
    {
        this.level = level;
        this.cardMax = cardMax;
        this.time = Time;
        this.type = type;
    }
}
