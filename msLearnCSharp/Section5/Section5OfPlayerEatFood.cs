using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section5
{
    public class Section5OfPlayerEatFood
    {
        // 成员变量
        private Random _random = new Random();
        private int _height;
        private int _width;
        private bool _shouldExit;
        // 玩家坐标
        private int _playerX;
        private int _playerY;
        // 食物坐标
        private int _foodX;
        private int _foodY;
        // 素材数组
        private readonly string[] _states = { "('-')", "(^-^)", "(X_X)" };
        private readonly string[] _foods = { "@@@@@", "$$$$$", "#####" };

        private string _player;
        private int _foodIndex;

        // 构造函数
        public Section5OfPlayerEatFood()
        {
            Console.CursorVisible = false;
            _height = Console.WindowHeight - 1;
            _width = Console.WindowWidth - 5;
            _shouldExit = false;

            _playerX = 0;
            _playerY = 0;
            _player = _states[0];
        }

        // 启动游戏主逻辑（对外暴露方法）
        public void StartGame()
        {
            InitializeGame();
            while (!_shouldExit)
            {
                if (TerminalResized())
                {
                    Console.Clear();
                    Console.Write("Console was resized. Program exiting.");
                    _shouldExit = true;
                }
                else
                {
                    if (PlayerIsFaster())
                    {
                        Move(1,false);
                    } else if (PlayerIsSick())
                    {
                        FreezePlayer();
                    } else
                    {
                        Move(otherKeysExit: false);
                    }
                    if (GetFood())
                    {
                        ChangePlayer();
                        ShowFood();
                    }
                }
                // Move();
            }
            // 游戏结束后恢复光标
            Console.CursorVisible = true;
        }

        // 初始化画面
        private void InitializeGame()
        {
            Console.Clear();
            ShowFood();
            Console.SetCursorPosition(0, 0);
            Console.Write(_player);
        }

        void ShowFood()
        {
            // Update food to a random index
            _foodIndex = _random.Next(0, _foods.Length);

            // Update food position to a random location
            _foodX = _random.Next(0, _width - _player.Length);
            _foodY = _random.Next(0, _height - 1);

            // Display the food at the location
            Console.SetCursorPosition(_foodX, _foodY);
            Console.Write(_foods[_foodIndex]);
        }

        void Move(int speed = 1, bool otherKeysExit = false)
        {
            int lastX = _playerX;
            int lastY = _playerY;

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    _playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    _playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    _playerX--;
                    break;
                case ConsoleKey.RightArrow:
                    _playerX++;
                    break;
                case ConsoleKey.Escape:
                    _shouldExit = true;
                    break;
                default:
                    _shouldExit = otherKeysExit;
                    break;
            }

            // Clear the characters at the previous position
            Console.SetCursorPosition(lastX, lastY);
            for (int i = 0; i < _player.Length; i++)
            {
                Console.Write(" ");
            }
            // Keep player position within the bounds of the Terminal window
            _playerX = (_playerX < 0) ? 0 : (_playerX >= _width ? _width : _playerX);
            _playerY = (_playerY < 0) ? 0 : (_playerY >= _height ? _height : _playerY);

            // Draw the player at the new location
            Console.SetCursorPosition(_playerX, _playerY);
            Console.Write(_player);
        }

        // Returns true if the Terminal was resized 
        bool TerminalResized()
        {
            return _height != Console.WindowHeight - 1 || _width != Console.WindowWidth - 5;
        }

        // Changes the player to match the food consumed
        void ChangePlayer()
        {
            _player = _states[_foodIndex];
            Console.SetCursorPosition(_playerX, _playerY);
            Console.Write(_player);
        }

        // Temporarily stops the player from moving
        void FreezePlayer()
        {
            System.Threading.Thread.Sleep(1000);
            _player = _states[0];
        }

        bool PlayerIsFaster()
        {
            return _player.Equals(_states[1]);
        }

        bool PlayerIsSick()
        {
            return _player.Equals(_states[2]);
        }
        bool GetFood()
        {
            return _playerY == _foodY && _playerX == _foodX;
        }


    }
}