namespace TextRPG
{
    public class BaseItem
    {
        public string? name;            //아이템 이름
        public string? explanation;     //아이템 설명

        public int attack;              //공격력
        public int defense;             //방어력

        public int gold;                //돈

        public ItemLanguage korean;     //한국어로 번역된 값 저장 구조체

        public BaseItem()
        {
            Init();
        }

        /// <summary>
        /// 생성시 호출 될 함수
        /// </summary>
        protected virtual void Init() {}
    }
}
