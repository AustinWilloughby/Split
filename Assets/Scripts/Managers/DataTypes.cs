using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypes {

    public enum World
    {
        WorldOne,
        WorldTwo,
    }

    public enum BulletOwner
    {
        Player = 11,
        Enemy = 13,
    }

    public const float worldDiffY = 82.5f;
    public const float worldOneY = 5.81f;
    public const float worldTwoY = -78.2f;
}
