/// <summary>
/// �������� ���� class
/// </summary>
public class Stage
{
    public int level;       //���� ����
    public int cardMax;     //ī�� ���
    public float time;      //�÷��� Ÿ��
    public BossType type;   //�������� �ƴ��� Ȯ�� �����ִ� enum

    public Stage(int level, int cardMax, float Time, BossType type = BossType.None)
    {
        this.level = level;
        this.cardMax = cardMax;
        this.time = Time;
        this.type = type;
    }
}
