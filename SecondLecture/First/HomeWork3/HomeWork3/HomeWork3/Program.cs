using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        int width = 80;
        int height = 20;

        Map map = new Map(width, height);

        map.print();

        // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
        Point p = new Point(4, 5);
        Snake snake = new Snake(p, 4, '*', Direction.NONE);
        snake.Draw();

        // 음식의 위치를 무작위로 생성하고, 그립니다.
        //FoodCreator foodCreator = new FoodCreator('$');
        //Point food = foodCreator.CreateFood();
        //food.Draw('$');

        // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
        while (true)
        {
            // 키 입력이 있는 경우에만 방향을 변경합니다.
            if (Console.KeyAvailable)
            {
                Direction dir = GetDir(Console.ReadKey(true));
                if (dir != Direction.NONE)
                {
                    snake.dir = dir;
                }
            }

            bool isGameOver = map.Draw(ref snake);

            if (isGameOver)
            {
                break;
            }


            // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
            // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.


            // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)
            
            Thread.Sleep(100); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)
        }
        Console.SetCursorPosition(0, height + 2);
        Console.WriteLine("GameOver");
    }

    static Direction GetDir(ConsoleKeyInfo info)
    {
        Direction dir;

        switch (info.Key)
        {
            case ConsoleKey.UpArrow:
                dir = Direction.UP;
                break;
            case ConsoleKey.DownArrow:
                dir = Direction.DOWN;
                break;
            case ConsoleKey.LeftArrow:
                dir = Direction.LEFT;
                break;
            case ConsoleKey.RightArrow:
                dir = Direction.RIGHT;
                break;
            default:
                dir = Direction.NONE;
                break;
        }

        return dir;
    }
}

public class Snake
{
    private Queue<Point> snakeQueue = new Queue<Point>();
    private Point head;
    private int length;
    private char sym;

    public Direction dir;

    public Snake(Point head, int length, char sym, Direction dir)
    {
        snakeQueue.Enqueue(head);
        this.head = head;
        this.length = length;
        this.sym = sym;
        this.dir = dir;
    }

    public Point NextMovePoint()
    {
        int x = head.pair.Key;
        int y = head.pair.Value;

        switch (dir)
        {
            case Direction.LEFT:
                x--;
                break;
            case Direction.RIGHT:
                x++;
                break;
            case Direction.UP:
                y--;
                break;
            case Direction.DOWN:
                y++;
                break;
            default:
                return null!;
        }

        return new Point(x, y);
    }

    public void Move(Point movePoint)
    {
        Point newHead = movePoint;
        head = newHead;

        snakeQueue.Enqueue(head);
    }

    public Point Draw()
    {
        head.Draw(sym);

        if (snakeQueue.Count - 1 == length)
        {
            Point p = snakeQueue.Dequeue();
            p.Clear();

            return p;
        }

        return null!;
    }
}

public class FoodCreator
{
    private char image;
    private char sym;

    public FoodCreator(char sym)
    {
        this.sym = sym;
    }

    public Point CreateFood(HashSet<KeyValuePair<int, int>> pointHashSet)
    {
        return new Point(1, 1);
    }
}

public class Map
{
    public HashSet<KeyValuePair<int, int>> pointHashSet = new HashSet<KeyValuePair<int, int>>();
    public Point foodPoint;
    private int width;
    private int height;

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Point p = new Point(y, x);
                
                pointHashSet.Add(new KeyValuePair<int, int>(x, y));
            }
        }
    }

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

    public void Draw(Point p)
    {

    }

    public bool IsGameOver(Point next)
    {

        if (next == null)
        {
            return false;
        }

        if (pointHashSet.Contains(next.pair))
        {
            return false;
        }

        return true;
    }

    public bool Draw(ref Snake snake)
    {
        if (snake.dir == Direction.NONE)
            return false;

        Point p = snake.NextMovePoint();

        if (IsGameOver(p))
        {
            return true;
        }

        snake.Move(p);

        pointHashSet.Remove(p.pair);

        Point tail = snake.Draw();

        if (tail != null)
            pointHashSet.Add(tail.pair);

        return false;
    }
}

public class Point
{
    public KeyValuePair<int, int> pair; 

    // Point 클래스 생성자
    public Point(int _x, int _y)
    {
        pair = new KeyValuePair<int, int>(_x, _y);
    }

    // 점을 그리는 메서드
    public void Draw(char draw)
    {
        Console.SetCursorPosition(pair.Key, pair.Value);
        Console.Write(draw);
    }

    // 점을 지우는 메서드
    public void Clear()
    {
        Draw(' ');
    }

    // 두 점이 같은지 비교하는 메서드
    //public bool IsHit(Point p)
    //{
    //    return p.x == x && p.y == y;
    //}
}
// 방향을 표현하는 열거형입니다.
public enum Direction
{
    NONE,
    LEFT,
    RIGHT,
    UP,
    DOWN
}