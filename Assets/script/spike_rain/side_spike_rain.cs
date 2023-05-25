using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side_spike_rain : MonoBehaviour
{
    public spikes_rain game;
    public game_db gmdb;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && gameObject.tag == "sider")
        {
            if (game.need_dir_t.text == ">")
            {

                game.need_dir_t.text = "<";
                gmdb.rain_score++;
                game.score_t.text = "" + gmdb.rain_score;
            }
        }
        if (collision.gameObject.tag == "player" && gameObject.tag == "sidel")
        {
            if (game.need_dir_t.text == "<")
            {
                game.need_dir_t.text = ">";
                gmdb.rain_score++;
                game.score_t.text = "" + gmdb.rain_score;
            }
        }
    }
}