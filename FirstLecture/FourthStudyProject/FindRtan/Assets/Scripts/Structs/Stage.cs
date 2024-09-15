/// <summary>
/// 스테이지 구성 class
/// </summary>
public class Stage
{
    public int level;       //현재 레벨
    public int cardMax;     //카드 장수
    public float time;      //플레이 타임
    public BossType type;   //보스인지 아닌지 확인 시켜주는 enum

    public Stage(int level, int cardMax, float Time, BossType type = BossType.None)
    {
        this.level = level;
        this.cardMax = cardMax;
        this.time = Time;
        this.type = type;
    }
}
