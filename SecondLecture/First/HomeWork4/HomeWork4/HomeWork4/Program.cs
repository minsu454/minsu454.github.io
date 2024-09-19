internal class Program
{
    static void Main(string[] args)
    {
        Stage stage = new Stage();

        stage.Start();

        while (!stage.isGameOver)
        {
            stage.Turn();

            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

public interface ICharacter
{
    public string name { get; set; }
    public int health { get; set; }
    public int attack { get; set; }
    public bool isDead { get; set; }

    public void TakeDamage(int damage);
}

public class Unit : ICharacter
{
    public string name { get; set; } = "";
    public int health { get; set; }
    public int attack { get; set; }
    public bool isDead { get; set; }

    public void Init(string name, int health, int attack)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
        isDead = false;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }

    public virtual int Input()
    {
        return 0;
    }
}

public class Warrior : Unit
{
    public Dictionary<ItemType, int> inventoryDic = new Dictionary<ItemType, int>();
    private HealthPotion healthPotion = new HealthPotion();         //hp포션
    private StrengthPotion strengthPotion = new StrengthPotion();   //힘포션

    public Warrior()
    {
        for (int i = 0; i < Enum.GetValues(typeof(ItemType)).Length - 1; i++)
        {
            inventoryDic.Add((ItemType)(i + 1), 0);
        }
    }

    public void UseItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.HealthPotion:
                healthPotion.Use(this);
                Console.WriteLine("HP 5 증가!!");
                break;
            case ItemType.StrengthPostion:
                strengthPotion.Use(this);
                Console.WriteLine("힘 1 증가!!");
                break;
        }
    }

    public override int Input()
    {
        int.TryParse(Console.ReadLine(), out int num);
        return num;
    }
}

public enum ActionType
{
    None = 0,
    Attack,
    UseItem,
}

public class Monster : Unit
{
    public override int Input()
    {
        return 1;
    }
}

public class Goblin : Monster
{
    public Goblin(string name, int health, int attack)
    {
        Init(name, health, attack);
    }
}

public class Dragon : Monster
{
    public Dragon(string name, int health, int attack)
    {
        Init(name, health, attack);
    }
}

public enum MonsterType
{
    None = 0,
    Goblin = 1,
    Dragon = 2,
}

public interface IItem
{
    public string name { get; set; }

    public void Use(Warrior warrior);
}

public class HealthPotion : IItem
{
    public string name { get; set; }

    public HealthPotion()
    {
        name = ItemType.HealthPotion.ToString();
    }

    public void Use(Warrior warrior)
    {
        warrior.health += 5;
    }
}

public class StrengthPotion : IItem
{
    public string name { get; set; }

    public StrengthPotion()
    {
        name = ItemType.StrengthPostion.ToString();
    }

    public void Use(Warrior warrior)
    {
        warrior.attack++;
    }
}

public enum ItemType
{
    None = 0,
    HealthPotion,
    StrengthPostion,

}

public class Stage
{
    private List<Chapter> chapterList = new List<Chapter>();        //스테이지list
    private Queue<Unit> turnQueue = new Queue<Unit>();              //턴 바꿔주는 Queue
    private Warrior warrior = new Warrior();                        //플레이어 캐릭터
    private int curChapterIdx = 0;                                  //스테이지index

    public bool isGameOver = false;                                 //게임오버 변수

    public Stage()
    {
        CreateChapters();
    }

    /// <summary>
    /// 챕터 생성해주는 함수
    /// </summary>
    public void CreateChapters()
    {
        chapterList.Add(new Chapter("Chapter1", MonsterType.Goblin));
        chapterList.Add(new Chapter("Chapter2", MonsterType.Goblin));
        chapterList.Add(new Chapter("Chapter3", MonsterType.Goblin));
        chapterList.Add(new Chapter("Chapter4", MonsterType.Goblin));
        chapterList.Add(new Chapter("Chapter5", MonsterType.Dragon));
    }

    /// <summary>
    /// 게임 시작하는 함수
    /// </summary>
    public void Start()
    {
        warrior.Init("사탄", 15, 3);
        ResetTurn();
    }

    /// <summary>
    /// 몬스터 소환해주는 함수
    /// </summary>
    public void ResetTurn()
    {
        turnQueue.Clear();
        turnQueue.Enqueue(warrior);
        turnQueue.Enqueue(chapterList[curChapterIdx].monster);
    }

    /// <summary>
    /// 매턴마다 실행되는 함수
    /// </summary>
    public void Turn()
    {
        var unit = turnQueue.Dequeue();
        var nextUnit = turnQueue.Peek();
        PrintFightUI(unit.name);

        bool key = false;
        do
        {
            ActionType input = (ActionType)unit.Input();

            switch (input)
            {
                case ActionType.Attack:
                    nextUnit.TakeDamage(unit.attack);
                    key = true;
                    break;
                case ActionType.UseItem:
                    UseItem();
                    Console.Clear();
                    PrintFightUI(unit.name);
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    break;
            }

        } while (!key);

        if (nextUnit.isDead)
        {
            Console.Clear();
            PrintFightUI(unit.name);
            Thread.Sleep(1000);
            if (unit == warrior)
            {
                ChapterClear();
            }
            else
            {
                GameOver();
            }
        }

        turnQueue.Enqueue(unit);
    }

    /// <summary>
    /// 챕터 클리어 했을 때의 함수
    /// </summary>
    public void ChapterClear()
    {
        Console.Clear();
        Console.WriteLine("GameClear");

        curChapterIdx++;
        if (curChapterIdx >= chapterList.Count)
        {
            Console.Clear();
            Console.WriteLine("All Clear!!");
            isGameOver = true;
            return;
        }

        PrintItemChoiceUI();

        bool key = false;
        ItemType input;

        do
        {
            input = (ItemType)warrior.Input();

            switch (input)
            {
                case ItemType.HealthPotion:
                    key = true;
                    break;
                case ItemType.StrengthPostion:

                    key = true;
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    break;
            }

        } while (!key);

        Console.WriteLine();
        Console.WriteLine($"{(int)input}번 아이템을 획득했습니다.");

        warrior.inventoryDic[input]++;

        ResetTurn();
    }

    /// <summary>
    /// 게임오버 함수
    /// </summary>
    public void GameOver()
    {
        Console.Clear();
        Console.WriteLine("GameOver");
        isGameOver = true;
    }

    public void UseItem()
    {
        PrintItemChoiceUI();
        Console.WriteLine("3. 돌아가기");

        bool key = false;
        ItemType input;

        do
        {
            int temp = warrior.Input();

            if (temp == 0)
                temp = -1;
            else if (temp == 3)
                temp = 0;

            input = (ItemType)temp;

            switch (input)
            {
                case ItemType.HealthPotion:
                    key = true;
                    break;
                case ItemType.StrengthPostion:
                    key = true;
                    break;
                case ItemType.None:
                    key = true;
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    break;
            }

            if (warrior.inventoryDic.TryGetValue(input, out int value))
            {
                if (value == 0)
                {
                    Console.WriteLine("선택한 아이템이 없습니다.");
                    key = false;
                }
            }

        } while (!key);

        if (input == ItemType.None)
            return;

        Console.WriteLine($"{(int)input}번 아이템을 사용했습니다. ");
        warrior.UseItem(input);
        warrior.inventoryDic[input]--;

        Thread.Sleep(1000);
    }

    /// <summary>
    /// 아이템 선택 UI 함수
    /// </summary>
    public void PrintItemChoiceUI()
    {
        Console.WriteLine();

        Console.WriteLine($"아이템을 선택하세요");
        Console.WriteLine($"1. 체력포션");
        Console.WriteLine($"2. 힘포션");
    }

    /// <summary>
    /// 싸울때 나오는 UI 함수
    /// </summary>
    public void PrintFightUI(string name)
    {
        Console.WriteLine(chapterList[curChapterIdx].name);
        Console.WriteLine($"플레이어 남은 HP {warrior.health}         체력포션{warrior.inventoryDic[ItemType.HealthPotion]} 힘포션{warrior.inventoryDic[ItemType.StrengthPostion]}");
        Console.WriteLine();
        Console.WriteLine($"{chapterList[curChapterIdx].monster.name} 남은 체력 HP {chapterList[curChapterIdx].monster.health}");

        Console.WriteLine();

        Console.WriteLine($"{name}의 턴!!");
        Console.WriteLine("무엇을 할까? (1.공격, 2.아이템 사용)");
    }
}

public class Chapter
{
    public string name;
    public Monster monster { get; private set; }

    public Chapter(string name, MonsterType type)
    {
        this.name = name;
        monster = ToMonster(type);
    }

    public Monster ToMonster(MonsterType type)
    {
        switch (type)
        {
            case MonsterType.None:
                return null!;
            case MonsterType.Goblin:
                return new Goblin(type.ToString(), 5, 1);
            case MonsterType.Dragon:
                return new Dragon(type.ToString(), 20, 5);
        }
        return null!;
    }
}