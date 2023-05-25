using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public classic_game game;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && game.gmdb.jumppower != 0)
        {
            game.player.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            game.plan.Play("pl_dest");
            game.gmdb.jumppower = 0;
            if (game.gmdb.direction == 1)
            {
                game.gmdb.direction = -1;
            }
            else if (game.gmdb.direction == -1)
            {
                game.gmdb.direction = 1;
            }

            game.spike_hide_l();
            game.spike_hide_r();
            game.rez_op();
        }
    }
}
