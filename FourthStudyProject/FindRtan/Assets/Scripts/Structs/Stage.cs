using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public int level;
    public int cardMax;
    public float time;
    public bool isBoss;
    public BossType type;

    public Stage(int level, int cardMax, float Time, bool isBoss = false, BossType type = BossType.None)
    {
        this.level = level;
        this.cardMax = cardMax;
        this.time = Time;
        this.isBoss = isBoss;
        this.type = type;
    }
}
