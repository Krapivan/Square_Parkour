using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_spikes_rain : MonoBehaviour
{
    public game_db gmdb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            gmdb.coinpl++;

            gameObject.GetComponent<Animation>().Play("coin_take");
            Invoke("coin_del", 0.22f);
        }
        if (collision.gameObject.tag == "spike_del")
        {
            Destroy(gameObject);
        }
    }

    void coin_del()
    {
        Destroy(gameObject);
    }
}
