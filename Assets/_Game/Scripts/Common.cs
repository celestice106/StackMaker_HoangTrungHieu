using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameTag
{
    public const string PLAYER = "Player";
    public const string BRICK = "Brick";
    public const string UNBRICK = "UnBrick";
    public const string BRICK_TAKER = "BrickTaker";
    public const string WINZONE = "WinZone";
    public const string FINISH_LINE = "FinishLine";
}
public static class GameAnim
{
    public static class Duration
    {
        public static class Player
        {
            public const float IDLE = 1.1f;
            public const float JUMP = 0.17f;
            public const float CHEER = 6.14f;
        }
        public static class Pusher
        {
            public const float BOUNCE = 0.5f;
        }
        public static class SceneTransition
        {
            public const float START_SCENE = 1.5f;
            public const float END_SCENE = 1.5f;
        }
    }
}

public static class GameConstant
{
    public static class Bridge
    {
        //public const string LAYER_NAME = "Brick Taker";
        public static readonly Color[] WINZONE_COLORS =
        {
            Color.red,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.blue,
            Color.magenta,
            Color.gray,
            Color.white
        };
    }
    public static class Brick
    {
        public const float THICKNESS = 0.315001f;
        public static class UnCollectable
        {
            public const string LAYER_NAME = "UnBrick";
        }
    }
    public static class Level
    {
        public static class Reward
        {
            public const int GOLD = 50;
        }
    }

    public static class GameData
    {
        public const int DEFAULT_ASSET = 0;
        public const int DEFAULT_LEVEL = 1;
        public static class Keys
        {
            public const string GOLD = "gold";
            public const string LEVEL = "level";
        }
    }
}

