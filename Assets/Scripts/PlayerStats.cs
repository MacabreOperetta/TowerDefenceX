using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startmoney = 400;
    public static int lives;
    public int startlife = 20;
    public static int round;
    private void Start()
    {
        money = startmoney;
        lives = startlife;
        round = 0;
    }
}
