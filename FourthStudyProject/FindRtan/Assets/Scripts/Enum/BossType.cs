/// <summary>
/// ���� Ÿ��
/// </summary>
public enum BossType
{
    None = 0,
    Same = 1 << 0,          //ī�尡 ���� �Ȱ������� ����Ÿ��
    Shuffle = 1 << 1,       //ī�尡 �ֱ������� ���õǴ� ����Ÿ��
    ImageError = 1 << 2,    //�̹����� ī�峻��(index)�� �����ʴ� ����Ÿ��
}