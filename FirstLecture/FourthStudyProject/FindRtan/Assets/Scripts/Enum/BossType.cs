/// <summary>
/// 보스 타입
/// </summary>
public enum BossType
{
    None = 0,
    Same = 1 << 0,          //카드가 전부 똑같아지는 보스타입
    Shuffle = 1 << 1,       //카드가 주기적으로 셔플되는 보스타입
    ImageError = 1 << 2,    //이미지와 카드내용(index)가 맞지않는 보스타입
}