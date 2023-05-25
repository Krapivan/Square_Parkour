using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "db/player_db")]
public class game_db : ScriptableObject
{
    public int start;
    public int coin;
    public int coinpl;
    public int rejim;

    public int classic_best_score;
    public int classic_score;

    public int rain_best_score;
    public int rain_score;

    public float speed;
    public float jumppower;
    public int direction;
}
