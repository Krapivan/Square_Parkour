using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_spikes_rain : MonoBehaviour
{
    public game_db gmdb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && gmdb.speed != 0)
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            collision.gameObject.GetComponent<Animation>().Play("pl_dest");
            gmdb.speed = 0f;
        }
        if (collision.gameObject.tag == "spike_del")
        {
            Destroy(gameObject);
        }
    }
}
