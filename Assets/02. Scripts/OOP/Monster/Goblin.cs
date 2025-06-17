using NUnit.Framework.Internal;
using UnityEngine;

public class Goblin : Monster
{
    public override void Init()
    {
        hp = 3f;
        moveSpeed = 3f;
    }
}
