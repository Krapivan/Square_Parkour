using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/skin_db")]
public class skin_db : ScriptableObject
{
    public int skin_now;
    public int skin_ch;
    public string[] skin_name = new string[1];
    public Sprite[] skin_all = new Sprite[1];
    public int[] skin_price = new int[1];
    public int[] skin_have = new int[1];
    public Sprite[] spr = new Sprite[1];

    public Sprite[] rj = new Sprite[1];
    public string[] rj_name = new string[1];
    public int rj_now;
}
