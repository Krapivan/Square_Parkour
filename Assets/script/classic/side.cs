using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side : MonoBehaviour
{
    public classic_game game;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && game.gmdb.direction == 1 && game.gmdb.jumppower != 0)
        {
            game.gmdb.direction = -1;
            game.player.gameObject.transform.eulerAngles = new Vector2(game.player.gameObject.transform.eulerAngles.x, -180);

            game.gmdb.classic_score++;
            game.score_t.text = "" + game.gmdb.classic_score;
            game.spike_spawner(2);
            spped_up();
        }
        else if (collision.gameObject.tag == "player" && game.gmdb.direction == -1 && game.gmdb.jumppower != 0)
        {
            game.gmdb.direction = 1;
            game.player.gameObject.transform.eulerAngles = new Vector2(game.player.gameObject.transform.eulerAngles.x, 0);

            game.gmdb.classic_score++;
            game.score_t.text = "" + game.gmdb.classic_score;
            game.spike_spawner(1);
            spped_up();
        }
    }

    void spped_up()
    {
        int score = game.gmdb.classic_score;
        int cost = 6;
        int upc = 0;

        while (score >= cost)
        {
            score -= cost;
            upc++;
            cost = cost * 2;
        }

        for (int i = 1; i <= upc; i++)
        {
            game.gmdb.speed = 2.5f + 0.1f;
        }
    }
}
