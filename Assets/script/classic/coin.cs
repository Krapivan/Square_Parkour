using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public classic_game game;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            game.gmdb.coinpl++;
            game.coin_t.text = "+" + game.gmdb.coinpl;

            gameObject.GetComponent<Animation>().Play("coin_take");
            Invoke("coin_del", 0.22f);
            Invoke("coin_new", 0.5f);
        }
    }
    void coin_del()
    {
        gameObject.SetActive(false);
    }
    void coin_new()
    {
        game.coin_spawner();
    }
}
