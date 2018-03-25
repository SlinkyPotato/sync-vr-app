using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class GameModel
{
    public int score;
    public bool didWin;
    public int gameTimeSecs;

    public GameModel() {}

    public GameModel(int score, bool didWin, int gameTimeSecs)
    {
        this.score = score;
        this.didWin = didWin;
        this.gameTimeSecs = gameTimeSecs;
    }
}
