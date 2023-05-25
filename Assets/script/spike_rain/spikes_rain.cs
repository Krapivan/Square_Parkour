using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spikes_rain : MonoBehaviour
{
    System.Random rnd = new System.Random();

    public game_save save;
    public skin_db skdb;
    public game_db gmdb;

    public Image player;
    public Animation plan;
    public Rigidbody2D plrb;

    public Text score_t, need_dir_t, coin_t, rez_t;
    public GameObject rez_pn, repl_pn, menu_pn, spike, coin, canvas;

    public Transform[] sp_poz;

    public void Start()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        plrb.GetComponent<Rigidbody2D>();
        player.GetComponent<BoxCollider2D>().isTrigger = false;
        player.sprite = skdb.skin_all[skdb.skin_now - 1];

        gmdb.direction = 0;
        gmdb.speed = 2.7f;
        gmdb.coinpl = 0;
        gmdb.rain_score = 0;
        score_t.text = "" + gmdb.rain_score;
        need_dir_t.text = ">";
    }

    private void FixedUpdate()
    {
        if (gmdb.direction != 0)
        {
            move();
            coin_t.text = "" + gmdb.coinpl;
        }
        if (gmdb.speed == 0f)
        {
            if (gmdb.direction != 0)
            {
                rez_op();
            }
            gmdb.direction = 0;
        }
    }

    void move()
    {
        plrb.velocity = new Vector2(gmdb.direction * gmdb.speed, 0);
    }

    public void mover_b()
    {
        if (gmdb.direction != 0)
        {
            player.gameObject.transform.localScale = new Vector2(1, 1);
            gmdb.direction = 1;
        }
        else if (gmdb.direction == 0)
        {
            player.gameObject.transform.localScale = new Vector2(1, 1);
            gmdb.direction = 1;
            Invoke("spike_spawner", 1f);
            Invoke("coin_spawner", 3f);
        }
    }
    public void movel_b()
    {
        if (gmdb.direction != 0)
        {
            player.gameObject.transform.localScale = new Vector2(-1, 1);
            gmdb.direction = -1;
        }
        else if (gmdb.direction == 0)
        {
            player.gameObject.transform.localScale = new Vector2(-1, 1);
            gmdb.direction = -1;
            Invoke("spike_spawner", 1f);
            Invoke("coin_spawner", 3f);
        }
    }

    public void repl_b()
    {
        repl_cls();
        Invoke("menu_cls", 0.05f);
        Invoke("rez_cls", 0.3f);

        SceneManager.LoadScene("spikes_rain");
    }
    public void menu_b()
    {
        repl_cls();
        Invoke("menu_cls", 0.05f);
        Invoke("rez_cls", 0.3f);

        SceneManager.LoadScene("title");
    }

    void spike_spawner()
    {
        if (gmdb.speed == 0) { return; }
        int poznum = rnd.Next(1,10);

        switch (poznum)
        {
            case 1:
                Instantiate(spike, sp_poz[0].position, Quaternion.identity, canvas.transform);
                break;
            case 2:
                Instantiate(spike, sp_poz[1].position, Quaternion.identity, canvas.transform);
                break;
            case 3:
                Instantiate(spike, sp_poz[2].position, Quaternion.identity, canvas.transform);
                break;
            case 4:
                Instantiate(spike, sp_poz[3].position, Quaternion.identity, canvas.transform);
                break;
            case 5:
                Instantiate(spike, sp_poz[4].position, Quaternion.identity, canvas.transform);
                break;
            case 6:
                Instantiate(spike, sp_poz[5].position, Quaternion.identity, canvas.transform);
                break;
            case 7:
                Instantiate(spike, sp_poz[6].position, Quaternion.identity, canvas.transform);
                break;
            case 8:
                Instantiate(spike, sp_poz[7].position, Quaternion.identity, canvas.transform);
                break;
            case 9:
                Instantiate(spike, sp_poz[8].position, Quaternion.identity, canvas.transform);
                break;
        }

        float time = 2f;
        int score = gmdb.rain_score;
        int cost = 4;
        int tt = 0;

        while (score >= cost)
        {
            score -= cost;
            tt++;
            cost = (cost * 14)/10;
        }
        time = time - (0.1f * tt);
        if (time < 0.4f)
        {
            time = 0.4f;
        }

        Invoke("spike_spawner", time);
    }
    void coin_spawner()
    {
        if (gmdb.speed == 0) { return; }
        int poznum = rnd.Next(1, 10);

        switch (poznum)
        {
            case 1:
                Instantiate(coin, sp_poz[0].position, Quaternion.identity, canvas.transform);
                break;
            case 2:
                Instantiate(coin, sp_poz[1].position, Quaternion.identity, canvas.transform);
                break;
            case 3:
                Instantiate(coin, sp_poz[2].position, Quaternion.identity, canvas.transform);
                break;
            case 4:
                Instantiate(coin, sp_poz[3].position, Quaternion.identity, canvas.transform);
                break;
            case 5:
                Instantiate(coin, sp_poz[4].position, Quaternion.identity, canvas.transform);
                break;
            case 6:
                Instantiate(coin, sp_poz[5].position, Quaternion.identity, canvas.transform);
                break;
            case 7:
                Instantiate(coin, sp_poz[6].position, Quaternion.identity, canvas.transform);
                break;
            case 8:
                Instantiate(coin, sp_poz[7].position, Quaternion.identity, canvas.transform);
                break;
            case 9:
                Instantiate(coin, sp_poz[8].position, Quaternion.identity, canvas.transform);
                break;
        }

        float time = 4f;

        Invoke("coin_spawner", time);
    }

    public void rez_op()
    {
        rez_pn.SetActive(true);
        rez_pn.GetComponent<Animation>().Play("rez_op");

        if (gmdb.rain_score > gmdb.rain_best_score)
        {
            rez_t.text = "►SCORE◄\n" + gmdb.rain_score + "★\n►COIN◄\n" + gmdb.coinpl;
            gmdb.rain_best_score = gmdb.rain_score;
            gmdb.coin += gmdb.coinpl;
        }
        else
        {
            rez_t.text = "►SCORE◄\n" + gmdb.rain_score + "\n►COIN◄\n" + +gmdb.coinpl;
            gmdb.coin += gmdb.coinpl;
        }

        save.save();

        Invoke("repl_op", 0.22f);
        Invoke("menu_op", 0.27f);
    }
    void rez_cls()
    {
        rez_pn.GetComponent<Animation>().Play("rez_cls");
        Invoke("rez_off", 0.22f);
    }
    void rez_off()
    {
        rez_pn.SetActive(false);
    }

    void repl_op()
    {
        repl_pn.SetActive(true);
        repl_pn.GetComponent<Animation>().Play("repl_op");
    }
    void repl_cls()
    {
        repl_pn.GetComponent<Animation>().Play("repl_cls");
        Invoke("repl_off", 0.17f);
    }
    void repl_off()
    {
        repl_pn.SetActive(false);
    }

    void menu_op()
    {
        menu_pn.SetActive(true);
        menu_pn.GetComponent<Animation>().Play("menu_op");
    }
    void menu_cls()
    {
        menu_pn.GetComponent<Animation>().Play("menu_cls");
        Invoke("menu_off", 0.22f);
    }
    void menu_off()
    {
        menu_pn.SetActive(false);
    }
}
