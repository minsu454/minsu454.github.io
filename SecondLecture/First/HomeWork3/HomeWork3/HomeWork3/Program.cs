#region Snake
using System;
using System.Collections.Generic;

class program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        int width = 80;
        int height = 20;

        map map = new map(width, height);

        map.print();

        // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
        point p = new point(4, 5);
        snake snake = new snake(p, 4, '*', direction.none);
        snake.draw();

        map.createfood();

        // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
        while (true)
        {
            // 키 입력이 있는 경우에만 방향을 변경합니다.
            if (Console.KeyAvailable)
            {
                direction dir = getdir(Console.ReadKey(true));
                if (dir != direction.none)
                {
                    snake.dir = dir;
                }
            }

            // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
            // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.
            bool isgameover = map.draw(ref snake);

            if (isgameover)
            {
                break;
            }

            // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)
            snake.print(width);

            Thread.Sleep(100); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)
        }
        Console.SetCursorPosition(0, height + 2);
        Console.WriteLine("gameover");
    }

    /// <summary>
    /// 키 입력 방향 반환해주는 함수
    /// </summary>
    static direction getdir(ConsoleKeyInfo info)
    {
        direction dir;

        switch (info.Key)
        {
            case ConsoleKey.UpArrow:
                dir = direction.up;
                break;
            case ConsoleKey.DownArrow:
                dir = direction.down;
                break;
            case ConsoleKey.LeftArrow:
                dir = direction.left;
                break;
            case ConsoleKey.RightArrow:
                dir = direction.right;
                break;
            default:
                dir = direction.none;
                break;
        }

        return dir;
    }
}

public class snake
{
    private Queue<point> snakeQueue = new Queue<point>();
    private point head;
    private int length;
    private int score = 0;
    private char sym;

    public direction dir;

    public snake(point head, int length, char sym, direction dir)
    {
        snakeQueue.Enqueue(head);
        this.head = head;
        this.length = length;
        this.sym = sym;
        this.dir = dir;
    }

    /// <summary>
    /// 뱀이 먹이를 먹었을 때 길이와 스코어 올려주는 함수
    /// </summary>
    public void sizeup()
    {
        length++;
        score++;
    }

    /// <summary>
    /// 뱀 길이와 스코어 보여주는 함수
    /// </summary>
    public void print(int width)
    {
        Console.SetCursorPosition(width + 5, 10);
        Console.Write($"길이 : {length}");
        Console.SetCursorPosition(width + 5, 11);
        Console.Write($"스코어 : {score}");
    }

    /// <summary>
    /// 뱀이 움직일 point를 반환해주는 함수
    /// </summary>
    public point nextmovepoint()
    {
        int x = head.pair.Key;
        int y = head.pair.Value;

        switch (dir)
        {
            case direction.left:
                x--;
                break;
            case direction.right:
                x++;
                break;
            case direction.up:
                y--;
                break;
            case direction.down:
                y++;
                break;
            default:
                return null!;
        }

        return new point(x, y);
    }

    /// <summary>
    /// 뱀머리 움직이는 함수
    /// </summary>
    public void move(point movepoint)
    {
        point newhead = movepoint;
        head = newhead;

        snakeQueue.Enqueue(head);
    }

    /// <summary>
    /// 뱀 그려주는 함수
    /// </summary>
    public point draw()
    {
        head.draw(sym);

        if (snakeQueue.Count - 1 == length)
        {
            point p = snakeQueue.Dequeue();
            p.clear();

            return p;
        }

        return null!;
    }
}

public class map
{
    private HashSet<KeyValuePair<int, int>> pointhashset = new HashSet<KeyValuePair<int, int>>();   //빈칸들 들고있을 hashset

    private point foodpoint = null!;        //지금 먹이 위치
    private int width;                      //가로길이
    private int height;                     //세로길이

    public map(int width, int height)
    {
        this.width = width;
        this.height = height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                point p = new point(y, x);

                pointhashset.Add(new KeyValuePair<int, int>(x, y));
            }
        }
    }

    /// <summary>
    /// 선 채워주는 함수
    /// </summary>
    public void print()
    {
        for (int i = 0; i < width; i++)
        {
            Console.SetCursorPosition(i, height);
            Console.Write('ㅡ');
        }

        for (int i = 0; i < height; i++)
        {
            Console.SetCursorPosition(width, i);
            Console.Write("|");
        }
    }

    /// <summary>
    /// 랜덤으로 먹이 만드는 함수
    /// </summary>
    public void createfood()
    {
        var set = pointhashset.ToList();

        Random rand = new Random();
        int idx = rand.Next(0, pointhashset.Count);

        point p = new point(set[idx]);
        foodpoint = p;
        foodpoint.draw('$');

        pointhashset.Remove(set[idx]);
    }

    /// <summary>
    /// pointhashset에 remove하는 함수
    /// </summary>
    /// <param name="p"></param>
    public void remove(point p)
    {
        pointhashset.Remove(p.pair);
    }

    /// <summary>
    /// 게임오버 체크해주는 함수
    /// </summary>
    public bool isgameover(point next)
    {
        if (next == null)
        {
            return false;
        }

        if (pointhashset.Contains(next.pair))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 맵에 있는 모든 것을 그려주는 함수
    /// </summary>
    public bool draw(ref snake snake)
    {
        if (snake.dir == direction.none)
            return false;

        point p = snake.nextmovepoint();

        if (p.issame(foodpoint.pair))
        {
            snake.sizeup();
            createfood();
        }
        else if (isgameover(p))
        {
            return true;
        }

        snake.move(p);

        remove(p);

        point tail = snake.draw();

        if (tail != null)
            pointhashset.Add(tail.pair);

        return false;
    }
}

public class point
{
    public KeyValuePair<int, int> pair;

    // point 클래스 생성자
    public point(int _x, int _y)
    {
        pair = new KeyValuePair<int, int>(_x, _y);
    }

    public point(KeyValuePair<int, int> pair)
    {
        this.pair = pair;
    }

    // 점을 그리는 메서드
    public void draw(char draw)
    {
        Console.SetCursorPosition(pair.Key, pair.Value);
        Console.Write(draw);
    }

    /// <summary>
    /// 받아온 pair가 this.pair와 같은지 알려주는 함수
    /// </summary>
    public bool issame(KeyValuePair<int, int> pair)
    {
        return this.pair.Key == pair.Key && this.pair.Value == pair.Value;
    }

    // 점을 지우는 메서드
    public void clear()
    {
        draw(' ');
    }
}
// 방향을 표현하는 열거형입니다.
public enum direction
{
    none,
    left,
    right,
    up,
    down
}

#endregion

#region Blackjack
//using System;
//using System.Collections.Generic;

//public enum Suit { Hearts, Diamonds, Clubs, Spades }
//public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

//// 카드 한 장을 표현하는 클래스
//public class Card
//{
//    public Suit Suit { get; private set; }
//    public Rank Rank { get; private set; }

//    public Card(Suit s, Rank r)
//    {
//        Suit = s;
//        Rank = r;
//    }

//    public int GetValue()
//    {
//        if ((int)Rank <= 10)
//        {
//            return (int)Rank;
//        }
//        else if ((int)Rank <= 13)
//        {
//            return 10;
//        }
//        else
//        {
//            return 11;
//        }
//    }

//    public override string ToString()
//    {
//        string s = "";
//        switch (Suit)
//        {
//            case Suit.Hearts:
//                s = "♡";
//                break;
//            case Suit.Diamonds:
//                s = "◇";
//                break;
//            case Suit.Clubs:
//                s = "♣";
//                break;
//            case Suit.Spades:
//                s = "♠";
//                break;
//        }

//        return $"{s}{(int)Rank}  ";
//    }
//}

//// 덱을 표현하는 클래스
//public class Deck
//{
//    private List<Card> cards;

//    public Deck()
//    {
//        cards = new List<Card>();

//        foreach (Suit s in Enum.GetValues(typeof(Suit)))
//        {
//            foreach (Rank r in Enum.GetValues(typeof(Rank)))
//            {
//                cards.Add(new Card(s, r));
//            }
//        }

//        Shuffle();
//    }

//    public void Shuffle()
//    {
//        Random rand = new Random();

//        for (int i = 0; i < cards.Count; i++)
//        {
//            int j = rand.Next(i, cards.Count);
//            Card temp = cards[i];
//            cards[i] = cards[j];
//            cards[j] = temp;
//        }
//    }

//    public Card DrawCard()
//    {
//        Card card = cards[0];
//        cards.RemoveAt(0);
//        return card;
//    }
//}

//// 패를 표현하는 클래스
//public class Hand
//{
//    private List<Card> cards;

//    public Hand()
//    {
//        cards = new List<Card>();
//    }

//    public void AddCard(Card card)
//    {
//        cards.Add(card);
//    }

//    public int GetTotalValue()
//    {
//        int total = 0;
//        int aceCount = 0;

//        foreach (Card card in cards)
//        {
//            if (card.Rank == Rank.Ace)
//            {
//                aceCount++;
//            }
//            total += card.GetValue();
//        }

//        while (total > 21 && aceCount > 0)
//        {
//            total -= 10;
//            aceCount--;
//        }

//        return total;
//    }

//    public int GetCount()
//    {
//        return cards.Count;
//    }

//    public void CardPrint()
//    {
//        foreach (Card card in cards)
//        {
//            Console.Write(card.ToString());
//        }
//    }
//}

//// 플레이어를 표현하는 클래스
//public class Player
//{
//    public Hand Hand { get; private set; }

//    public Player()
//    {
//        Hand = new Hand();
//    }

//    public Card DrawCardFromDeck(Deck deck)
//    {
//        Card drawnCard = deck.DrawCard();
//        Hand.AddCard(drawnCard);
//        return drawnCard;
//    }

//    public void CardPrint()
//    {
//        Hand.CardPrint();
//    }

//    public virtual string Input(int playerNum)
//    {
//        Console.Write($"Player{playerNum}에 턴 : ");
//        string input = Console.ReadLine()!;

//        return input;
//    }
//}

//// 여기부터는 학습자가 작성
//// 딜러 클래스를 작성하고, 딜러의 행동 로직을 구현하세요.
//public class Dealer : Player
//{
//    public override string Input(int playerNum)
//    {
//        if (Hand.GetTotalValue() < 17)
//        {
//            return "GO";
//        }

//        Console.Write($"Player{playerNum}에 턴 : ");
//        string input = Console.ReadLine()!;

//        return input;
//    }
//}

//// 블랙잭 게임을 구현하세요. 
//public class Blackjack
//{
//    private Deck deck = null!;
//    private List<Player> playerList = new List<Player>();
//    private List<bool> playStopList = new List<bool>();
//    public int turn = 0;
//    public bool isGameOver = false;

//    public Blackjack(int count)
//    {
//        playerList.Add(new Dealer());
//        playStopList.Add(false);

//        for (int i = 1; i < count; i++)
//        {
//            playerList.Add(new Player());
//            playStopList.Add(false);
//        }
//        Reset();
//    }

//    public void StartGame()
//    {
//        for (int i = 0; i < playerList.Count; i++)
//        {
//            playerList[i].DrawCardFromDeck(deck);
//            playerList[i].DrawCardFromDeck(deck);
//        }
//    }

//    public void Winner()
//    {
//        int winnerIdx = -1;
//        for (int i = 0; i < playerList.Count; i++)
//        {
//            if (playerList[i].Hand.GetTotalValue() > 21)
//            {
//                continue;
//            }

//            if (winnerIdx == -1)
//                winnerIdx = i;
//            else
//            {
//                if (playerList[i].Hand.GetTotalValue() > playerList[winnerIdx].Hand.GetTotalValue())
//                {
//                    winnerIdx = i;
//                }
//                else if (playerList[i].Hand.GetTotalValue() == playerList[winnerIdx].Hand.GetTotalValue())
//                {
//                    if (playerList[i].Hand.GetCount() > playerList[winnerIdx].Hand.GetCount())
//                    {
//                        winnerIdx = i;
//                    }
//                }
//            } 
//        }

//        Console.WriteLine((winnerIdx == -1) ? "비겼습니다." : $"승리자 : Player{winnerIdx + 1}");
//    }

//    public void PlayerTurn()
//    {
//        if (playStopList[turn])
//        {
//            return;
//        }

//        string input = playerList[turn].Input(turn + 1);


//        if (input == "GO" || input == "Go" || input == "go")
//        {
//            playerList[turn].DrawCardFromDeck(deck);
//        }
//        else if (input == "STOP" || input == "Stop" || input == "stop")
//        {
//            playStopList[turn] = true;
//        }

//        if (playerList[turn].Hand.GetTotalValue() > 21)
//        {
//            playStopList[turn] = true;
//        }
//    }

//    public void NextPlayerTurn()
//    {
//        bool isGameOver = true;
//        for(int i = 0; i < playStopList.Count; i++)
//        {
//            if (!playStopList[i])
//            {
//                isGameOver = false;
//            }
//        }
//        this.isGameOver = isGameOver;

//        turn++;
//        turn %= playerList.Count;
//    }

//    public void PrintUI()
//    {
//        for (int i = 0; i < playerList.Count; i++)
//        {
//            Console.Write($"Player{i + 1}의 점수 : {playerList[i].Hand.GetTotalValue()}  보유중인 카드 : ");
//            playerList[i].CardPrint();
//            Console.WriteLine();
//        }

//        Console.WriteLine();
//    }

//    public void Reset()
//    {
//        deck = new Deck();
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // 블랙잭 게임을 실행하세요
//        Blackjack blackjack = new Blackjack(2);
//        blackjack.StartGame();

//        while (!blackjack.isGameOver)
//        {
//            Console.Clear();

//            blackjack.PrintUI();

//            blackjack.PlayerTurn();
//            blackjack.NextPlayerTurn();
//        }

//        Console.WriteLine();
//        blackjack.Winner();
//    }
//}
#endregion