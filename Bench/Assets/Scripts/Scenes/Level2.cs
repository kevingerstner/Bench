﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelScript
{
    // Start is called before the first frame update
    public override void StartLevelActions()
    {
        AudioManager.instance.Stop("Peaceful");
        AudioManager.instance.Play("DarkAmbient");
    }
}
