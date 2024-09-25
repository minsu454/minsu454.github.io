using System.Reflection.Emit;

namespace TextRPG
{
    public class BaseInfo
    {
        public JobType job;             //직업 타입

        public int level;               //레벨
        public int maxExp;              //경험치 최고치
        public int curExp;              //현재 경험치


        public int TotalAttack
        {
            get { return attack + (levelAttackPoint * (level - 1)) + itemAttack; }
        }

        public int TotalDefense
        {
            get { return defense + (levelDefensePoint * (level - 1)) + itemDefense; }
        }

        public int attack;              //공격력
        public int defense;             //방어력
        public int curHp;                  //체력
        public int maxHp;                  //체력

        public int levelAttackPoint;    //성장 공격력
        public int levelDefensePoint;   //성장 방어력

        public int itemAttack;          //무기 공격력
        public int itemDefense;         //방어구 방어력

        public BaseInfo()
        {
            Init();
        }

        protected virtual void Init()
        {
            level = 1;
            itemAttack = 0;
            itemDefense = 0;
            setLevel();
        }

        public bool IsLevelUp(int exp)
        {
            bool value = false;
            
            if (exp >= maxExp)
            {
                value = true;
            }

            return value;
        }

        public void LevelUp()
        {
            level++;
            setLevel();
        }

        private void setLevel()
        {
            curExp = 0;
            maxExp = 100 + ((level - 1) * 20);
        }
    }
}
