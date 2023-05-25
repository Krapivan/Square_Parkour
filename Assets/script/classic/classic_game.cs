using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class classic_game : MonoBehaviour
{
    System.Random rnd = new System.Random();

    public game_save gm_save;
    public game_db gmdb;
    public skin_db skdb;

    public Image player;
    public Animation plan;
    public Rigidbody2D plrb;
    public Collision2D plcl;

    public GameObject rez_pn, repl_pn, menu_pn;
    public Text score_t, coin_t, rez_t;
    public Animation rez_an, repl_an, menu_an;

    public GameObject spr1, spr2, spr3, spr4, spr5, spr6, spr7, spr8, spr9, spr10, spr11, spr12, spr13, spr14, spr15;
    public GameObject spl1, spl2, spl3, spl4, spl5, spl6, spl7, spl8, spl9, spl10, spl11, spl12, spl13, spl14, spl15;
    public GameObject coin1, coin2, coin3, coin4, coin5, coin6, coin7, coin8, coin9, coin10, coin11;

    public void Start()
    {
        player.sprite = skdb.skin_all[skdb.skin_now - 1];
        plrb = player.gameObject.GetComponent<Rigidbody2D>();
        player.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

        plrb.mass = 0;
        plrb.gravityScale = 0;

        gmdb.coinpl = 0;
        gmdb.classic_score = 0;
        gmdb.direction = 0;
        gmdb.jumppower = 5.7f;
        gmdb.speed = 2.5f;

        score_t.text = "" + gmdb.classic_score;

        spike_spawner(1);
    }

    private void FixedUpdate()
    {
        if (gmdb.direction != 0)
        {
            move();
        }
    }

    void move()
    {
        plrb.velocity = new Vector2(gmdb.direction * gmdb.speed, plrb.velocity.y);
    }
    public void jump()
    {
        if (gmdb.direction == 0)
        {
            Invoke("coin_spawner",0.45f);
            plrb.mass = 0.6f;
            plrb.gravityScale = 1.5f;
            gmdb.direction = 1;
        }
        if (gmdb.jumppower != 0)
        {
            plan.Play("pl_jump");
            plrb.velocity = new Vector2(plrb.velocity.x, gmdb.jumppower);
        }
    }

    public void spike_spawner(int v)
    {
        //del spike
        if (v == 1)
        {
            spike_hide_l();
        }
        else if (v == 2) 
        {
            spike_hide_r();
        }

        //spike count search
        int score = gmdb.classic_score;
        int cost = 5;
        int spikec = 1;

        while (score >= cost)
        {
            score -= cost;
            spikec++;
            cost = cost * 2;
        }
        if (spikec > 11)
        {
            spikec = 11;
        }

        //random spikes
        int spikenum = 0;
        int[] spikesnum = new int[14];
        bool can = true;
        for (int i = 1; i <= spikec; i++)
        {
            spikenum = rnd.Next(1, 16);
            for (int j = 0; j < spikec; j++)
            {
                if (spikesnum[j] == spikenum)
                {
                    i -= 1;
                    can = false;
                }
            }
            if (can == true)
            {
                spikesnum[i - 1] = spikenum;
            }
            can = true;
        }

        //spawn
        if (v == 1)
        {
            for (int i = 0; i < spikec; i++)
            {
                switch (spikesnum[i])
                {
                    case 1:
                        spr1.SetActive(true);
                        spr1.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 2:
                        spr2.SetActive(true);
                        spr2.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 3:
                        spr3.SetActive(true);
                        spr3.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 4:
                        spr4.SetActive(true);
                        spr4.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 5:
                        spr5.SetActive(true);
                        spr5.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 6:
                        spr6.SetActive(true);
                        spr6.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 7:
                        spr7.SetActive(true);
                        spr7.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 8:
                        spr8.SetActive(true);
                        spr8.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 9:
                        spr9.SetActive(true);
                        spr9.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 10:
                        spr10.SetActive(true);
                        spr10.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 11:
                        spr11.SetActive(true);
                        spr11.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 12:
                        spr12.SetActive(true);
                        spr12.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 13:
                        spr13.SetActive(true);
                        spr13.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 14:
                        spr14.SetActive(true);
                        spr14.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 15:
                        spr15.SetActive(true);
                        spr15.GetComponent<Animation>().Play("spike_spawn");
                        break;
                }
            }
        }
        if (v == 2)
        {
            for (int i = 0; i < spikec; i++)
            {
                switch (spikesnum[i])
                {
                    case 1:
                        spl1.SetActive(true);
                        spl1.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 2:
                        spl2.SetActive(true);
                        spl2.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 3:
                        spl3.SetActive(true);
                        spl3.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 4:
                        spl4.SetActive(true);
                        spl4.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 5:
                        spl5.SetActive(true);
                        spl5.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 6:
                        spl6.SetActive(true);
                        spl6.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 7:
                        spl7.SetActive(true);
                        spl7.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 8:
                        spl8.SetActive(true);
                        spl8.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 9:
                        spl9.SetActive(true);
                        spl9.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 10:
                        spl10.SetActive(true);
                        spl10.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 11:
                        spl11.SetActive(true);
                        spl11.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 12:
                        spl12.SetActive(true);
                        spl12.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 13:
                        spl13.SetActive(true);
                        spl13.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 14:
                        spl14.SetActive(true);
                        spl14.GetComponent<Animation>().Play("spike_spawn");
                        break;
                    case 15:
                        spl15.SetActive(true);
                        spl15.GetComponent<Animation>().Play("spike_spawn");
                        break;
                }
            }
        }
    }
    public void spike_hide_r()
    {
        spr1.GetComponent<Animation>().Play("spike_hide");
        spr2.GetComponent<Animation>().Play("spike_hide");
        spr3.GetComponent<Animation>().Play("spike_hide");
        spr4.GetComponent<Animation>().Play("spike_hide");
        spr5.GetComponent<Animation>().Play("spike_hide");
        spr6.GetComponent<Animation>().Play("spike_hide");
        spr7.GetComponent<Animation>().Play("spike_hide");
        spr8.GetComponent<Animation>().Play("spike_hide");
        spr9.GetComponent<Animation>().Play("spike_hide");
        spr10.GetComponent<Animation>().Play("spike_hide");
        spr11.GetComponent<Animation>().Play("spike_hide");
        spr12.GetComponent<Animation>().Play("spike_hide");
        spr13.GetComponent<Animation>().Play("spike_hide");
        spr14.GetComponent<Animation>().Play("spike_hide");
        spr15.GetComponent<Animation>().Play("spike_hide");
        Invoke("spike_off_r", 0.15f);
    }
    void spike_off_r()
    {
        spr1.SetActive(false);
        spr2.SetActive(false);
        spr3.SetActive(false);
        spr4.SetActive(false);
        spr5.SetActive(false);
        spr6.SetActive(false);
        spr7.SetActive(false);
        spr8.SetActive(false);
        spr9.SetActive(false);
        spr10.SetActive(false);
        spr11.SetActive(false);
        spr12.SetActive(false);
        spr13.SetActive(false);
        spr14.SetActive(false);
        spr15.SetActive(false);
    }
    public void spike_hide_l()
    {
        spl1.GetComponent<Animation>().Play("spike_hide");
        spl2.GetComponent<Animation>().Play("spike_hide");
        spl3.GetComponent<Animation>().Play("spike_hide");
        spl4.GetComponent<Animation>().Play("spike_hide");
        spl5.GetComponent<Animation>().Play("spike_hide");
        spl6.GetComponent<Animation>().Play("spike_hide");
        spl7.GetComponent<Animation>().Play("spike_hide");
        spl8.GetComponent<Animation>().Play("spike_hide");
        spl9.GetComponent<Animation>().Play("spike_hide");
        spl10.GetComponent<Animation>().Play("spike_hide");
        spl11.GetComponent<Animation>().Play("spike_hide");
        spl12.GetComponent<Animation>().Play("spike_hide");
        spl13.GetComponent<Animation>().Play("spike_hide");
        spl14.GetComponent<Animation>().Play("spike_hide");
        spl15.GetComponent<Animation>().Play("spike_hide");
        Invoke("spike_off_l", 0.15f);
    }
    void spike_off_l()
    {
        spl1.SetActive(false);
        spl2.SetActive(false);
        spl3.SetActive(false);
        spl4.SetActive(false);
        spl5.SetActive(false);
        spl6.SetActive(false);
        spl7.SetActive(false);
        spl8.SetActive(false);
        spl9.SetActive(false);
        spl10.SetActive(false);
        spl11.SetActive(false);
        spl12.SetActive(false);
        spl13.SetActive(false);
        spl14.SetActive(false);
        spl15.SetActive(false);
    }

    public void coin_spawner()
    {
        int ch = coin_chaker();
        if (ch == 0)
        {
            int coinnum = rnd.Next(1, 12);
            switch (coinnum)
            {
                case 1:
                    coin1.SetActive(true);
                    coin1.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 2:
                    coin2.SetActive(true);
                    coin2.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 3:
                    coin3.SetActive(true);
                    coin3.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 4:
                    coin4.SetActive(true);
                    coin4.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 5:
                    coin5.SetActive(true);
                    coin5.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 6:
                    coin6.SetActive(true);
                    coin6.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 7:
                    coin7.SetActive(true);
                    coin7.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 8:
                    coin8.SetActive(true);
                    coin8.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 9:
                    coin9.SetActive(true);
                    coin9.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 10:
                    coin10.SetActive(true);
                    coin10.GetComponent<Animation>().Play("coin_spawn");
                    break;
                case 11:
                    coin11.SetActive(true);
                    coin11.GetComponent<Animation>().Play("coin_spawn");
                    break;
            }
        }
    }
    int coin_chaker()
    {
        int ch = 0;
        if (coin1.activeSelf == true)
        {
            ch = 1;
        }
        if (coin2.activeSelf == true)
        {
            ch = 1;
        }
        if (coin3.activeSelf == true)
        {
            ch = 1;
        }
        if (coin4.activeSelf == true)
        {
            ch = 1;
        }
        if (coin5.activeSelf == true)
        {
            ch = 1;
        }
        if (coin6.activeSelf == true)
        {
            ch = 1;
        }
        if (coin7.activeSelf == true)
        {
            ch = 1;
        }
        if (coin8.activeSelf == true)
        {
            ch = 1;
        }
        if (coin9.activeSelf == true)
        {
            ch = 1;
        }
        if (coin10.activeSelf == true)
        {
            ch = 1;
        }
        if (coin11.activeSelf == true)
        {
            ch = 1;
        }

        return ch;
    }

    public void repl_b()
    {
        repl_cls();
        Invoke("menu_cls", 0.05f);
        Invoke("rez_cls", 0.3f);

        SceneManager.LoadScene("classic_game");
    }
    public void menu_b()
    {
        repl_cls();
        Invoke("menu_cls", 0.05f);
        Invoke("rez_cls", 0.3f);

        SceneManager.LoadScene("title");
    }

    public void rez_op()
    {
        rez_pn.SetActive(true);
        rez_an.Play("rez_op");

        if (gmdb.classic_score > gmdb.classic_best_score)
        {
            rez_t.text = "►SCORE◄\n" + gmdb.classic_score + "★\n►COIN◄\n" + gmdb.coinpl;
            gmdb.classic_best_score = gmdb.classic_score;
            gmdb.coin += gmdb.coinpl;
        }
        else
        {
            rez_t.text = "►SCORE◄\n" + gmdb.classic_score + "\n►COIN◄\n" + +gmdb.coinpl;
            gmdb.coin += gmdb.coinpl;
        }

        gm_save.save();

        Invoke("repl_op", 0.22f);
        Invoke("menu_op", 0.27f);
    }
    void rez_cls()
    {
        rez_an.Play("rez_cls");
        Invoke("rez_off", 0.22f);
    }
    void rez_off()
    {
        rez_pn.SetActive(false);
    }

    void repl_op()
    {
        repl_pn.SetActive(true);
        repl_an.Play("repl_op");
    }
    void repl_cls()
    {
        repl_an.Play("repl_cls");
        Invoke("repl_off", 0.17f);
    }
    void repl_off()
    {
        repl_pn.SetActive(false);
    }

    void menu_op()
    {
        menu_pn.SetActive(true);
        menu_an.Play("menu_op");
    }
    void menu_cls()
    {
        menu_an.Play("menu_cls");
        Invoke("menu_off", 0.22f);
    }
    void menu_off()
    {
        menu_pn.SetActive(false);
    }
}
