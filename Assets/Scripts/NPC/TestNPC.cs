using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

public class TestNPC : NPCBase
{
    protected override void BetweenInteractions()
    {
        
    }

    public TestNPC() : base(Classification.Neutral, 100, 10, 1, "NPCTest")
    {
    }
}
