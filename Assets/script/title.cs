using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    public game_save gm_load;
    public game_db gmdb;
    public skin_db skdb;

    public GameObject bscore, coin, pl_b, shp_b, rj_b, skin, str, stl, buy, price, cls_b;
    public GameObject rj_im, rj_nb, rj_bb, rj_tb, rj_clsb;

    public Text coin_t, best_score_t, skin_name, price_t, rejim_t, rj_name;

    private void Start()
    {
        gm_load.load();

        score_and_rejim_load();
    }
    private void FixedUpdate()
    {
        coin_t.text = "" + gmdb.coin;
    }

    public void play_b()
    {
        int rejim = gmdb.rejim;
        if (rejim == 1)
        {
            SceneManager.LoadScene("classic_game");
        }
        else if (rejim == 2)
        {
            SceneManager.LoadScene("spikes_rain");
        }
    }
    public void shop_b()
    {
        shp_b.GetComponent<Animation>().Play("button_click");

        Invoke("title_norm_hide", 0.2f);
        Invoke("shop_op", 0.45f);

        skdb.skin_ch = skdb.skin_now;
        shp_load();
    }
    public void rejim_b()
    {
        rj_b.GetComponent<Animation>().Play("button_click");

        Invoke("title_norm_hide", 0.2f);
        Invoke("rj_op", 0.45f);


        skdb.rj_now = gmdb.rejim;
        rj_load();
    }

    //shp
    public void next_skin()
    {
        str.GetComponent<Animation>().Play("button_click");
        if (skdb.skin_ch + 1 <= skdb.skin_all.Length)
        {
            skdb.skin_ch++;
        }
        else
        {
            skdb.skin_ch = 1;
        }

        shp_load();
    }
    public void back_skin()
    {
        stl.GetComponent<Animation>().Play("button_click");
        if (skdb.skin_ch - 1 >= 1)
        {
            skdb.skin_ch--;
        }
        else
        {
            skdb.skin_ch = skdb.skin_all.Length;
        }

        shp_load();
    }
    public void shp_cls()
    {
        cls_b.GetComponent<Animation>().Play("button_click");
        Invoke("shop_hide", 0.15f);
        Invoke("title_norm_op", 0.4f);
    }
    public void buy_b()
    {
        buy.GetComponent<Animation>().Play("button_click");
        if (buy.GetComponent<Image>().sprite == skdb.spr[0])
        {
            int coin = gmdb.coin;
            int skid = skdb.skin_ch;
            int price = skdb.skin_price[skid - 1];

            if (coin >= price)
            {
                gmdb.coin -= price;
                skdb.skin_have[skid - 1] = 1;
            }
        }
        if (buy.GetComponent<Image>().sprite == skdb.spr[1])
        {
            skdb.skin_now = skdb.skin_ch;
        }
        shp_load();
        gm_load.save();
        coin_t.text = "" + gmdb.coin;
    }
    void shp_load()
    {
        int skid = skdb.skin_ch;
        if (skdb.skin_have[skid - 1] != 1)
        {
            price_t.text = "" + skdb.skin_price[skid - 1];
            buy.GetComponent<Image>().sprite = skdb.spr[0];
        }
        else if (skdb.skin_have[skid - 1] == 1 && skid != skdb.skin_now)
        {
            price_t.text = "HAVE";
            buy.GetComponent<Image>().sprite = skdb.spr[1];
        }
        else if (skdb.skin_have[skid - 1] == 1 && skid == skdb.skin_now)
        {
            price_t.text = "HAVE";
            buy.GetComponent<Image>().sprite = skdb.spr[2];
        }

        skin_name.text = skdb.skin_name[skid - 1];
        price_t.text = "" + skdb.skin_price[skid - 1];
        skin.GetComponent<Image>().sprite = skdb.skin_all[skid - 1];

    }

    //rj
    void rj_load()
    {
        rj_im.GetComponent<Image>().sprite = skdb.rj[skdb.rj_now - 1];

        if (skdb.rj_now == gmdb.rejim)
        {
            rj_tb.GetComponent<Image>().sprite = skdb.spr[2];
        }
        else if (skdb.rj_now != gmdb.rejim)
        {
            rj_tb.GetComponent<Image>().sprite = skdb.spr[1];
        }

        rj_name.text = "► " + skdb.rj_name[skdb.rj_now - 1] + " ◄";
    }
    public void rejim_take()
    {
        gmdb.rejim = skdb.rj_now;
        rj_load();
        gm_load.save();
    }
    public void rejib_nb()
    {
        rj_nb.GetComponent<Animation>().Play("button_click");
        rj_im.GetComponent<Animation>().Play("skin_swap_l");
        int rjn = skdb.rj_now;
        if (rjn + 1 <= skdb.rj.Length)
        {
            skdb.rj_now++;
        }
        else
        {
            skdb.rj_now = 1;
        }

        Invoke("rj_load", 0.15f);
    }
    public void rejib_bb()
    {
        rj_bb.GetComponent<Animation>().Play("button_click");
        rj_im.GetComponent<Animation>().Play("skin_swap_r");
        int rjn = skdb.rj_now;
        if (rjn - 1 >= 1)
        {
            skdb.rj_now--;
        }
        else
        {
            skdb.rj_now = skdb.rj.Length;
        }

        Invoke("rj_load", 0.15f);
    }
    public void rj_cls()
    {
        rj_clsb.GetComponent<Animation>().Play("button_click");
        Invoke("rj_hide", 0.15f);
        Invoke("title_norm_op", 0.4f);
        score_and_rejim_load();
    }


    void title_norm_hide()
    {
        bscore.GetComponent<Animation>().Play("bscore_cls");
        rejim_t.gameObject.GetComponent<Animation>().Play("bscore_cls");
        pl_b.GetComponent<Animation>().Play("play_b_cls");
        shp_b.GetComponent<Animation>().Play("shop_b_cls");
        rj_b.GetComponent<Animation>().Play("shop_b_cls");
        Invoke("title_noem_off", 0.3f);
    }
    public void title_noem_off()
    {
        bscore.SetActive(false);
        rejim_t.gameObject.SetActive(false);
        pl_b.SetActive(false);
        shp_b.SetActive(false);
        rj_b.SetActive(false);
    }
    public void title_norm_op()
    {
        bscore.SetActive(true);
        bscore.GetComponent<Animation>().Play("bscore_op");
        rejim_t.gameObject.SetActive(true);
        rejim_t.gameObject.GetComponent<Animation>().Play("bscore_op");
        pl_b.SetActive(true);
        pl_b.GetComponent<Animation>().Play("play_b_op");
        shp_b.SetActive(true);
        shp_b.GetComponent<Animation>().Play("shop_b_op");
        rj_b.SetActive(true);
        rj_b.GetComponent<Animation>().Play("shop_b_op");
    }

    void shop_hide()
    {
        cls_b.GetComponent<Animation>().Play("cls_cls");
        skin.GetComponent<Animation>().Play("skin_cls");
        str.GetComponent<Animation>().Play("str_cls");
        stl.GetComponent<Animation>().Play("stl_cls");
        buy.GetComponent<Animation>().Play("buy_cls");
        price.GetComponent<Animation>().Play("price_cls");
        price_t.gameObject.GetComponent<Animation>().Play("price_t_cls");
        skin_name.gameObject.GetComponent<Animation>().Play("skin_name_cls");
        Invoke("shop_off", 0.22f);
    }
    void shop_off()
    {
        cls_b.SetActive(false);
        skin.SetActive(false);
        str.SetActive(false);
        stl.SetActive(false);
        buy.SetActive(false);
        price.SetActive(false);
        price_t.gameObject.SetActive(false);
        skin_name.gameObject.SetActive(false);
    }
    void shop_op()
    {
        cls_b.SetActive(true);
        cls_b.GetComponent<Animation>().Play("cls_op");
        skin.SetActive(true);
        skin.GetComponent<Animation>().Play("skin_op");
        Invoke("skin_an", 0.3f);
        str.SetActive(true);
        str.GetComponent<Animation>().Play("str_op");
        stl.SetActive(true);
        stl.GetComponent<Animation>().Play("stl_op");
        buy.SetActive(true);
        buy.GetComponent<Animation>().Play("buy_op");
        price.SetActive(true);
        price.GetComponent<Animation>().Play("price_op");
        Invoke("price_an", 0.4f);
        price_t.gameObject.SetActive(true);
        price_t.gameObject.GetComponent<Animation>().Play("price_t_op");
        skin_name.gameObject.SetActive(true);
        skin_name.gameObject.GetComponent<Animation>().Play("skin_name_op");
    }

    void rj_hide()
    {
        rj_clsb.GetComponent<Animation>().Play("cls_cls");
        rj_im.GetComponent<Animation>().Play("skin_cls");
        rj_nb.GetComponent<Animation>().Play("str_cls");
        rj_bb.GetComponent<Animation>().Play("stl_cls");
        rj_tb.GetComponent<Animation>().Play("buy_cls");
        rj_name.gameObject.GetComponent<Animation>().Play("skin_name_cls");
        Invoke("rj_off", 0.22f);
    }
    void rj_off()
    {
        rj_clsb.SetActive(false);
        rj_im.SetActive(false);
        rj_nb.SetActive(false);
        rj_bb.SetActive(false);
        rj_tb.SetActive(false);
        rj_name.gameObject.SetActive(false);
    }
    void rj_op()
    {
        rj_clsb.SetActive(true);
        rj_clsb.GetComponent<Animation>().Play("cls_op");
        rj_im.SetActive(true);
        rj_im.GetComponent<Animation>().Play("skin_op");
        rj_nb.SetActive(true);
        rj_nb.GetComponent<Animation>().Play("str_op");
        rj_bb.SetActive(true);
        rj_bb.GetComponent<Animation>().Play("stl_op");
        rj_tb.SetActive(true);
        rj_tb.GetComponent<Animation>().Play("buy_op");
        rj_name.gameObject.SetActive(true);
        rj_name.gameObject.GetComponent<Animation>().Play("skin_name_op");
    }

    void skin_an()
    {
        skin.GetComponent<Animation>().Play("skin_an");
    }
    void price_an()
    {
        price.GetComponent<Animation>().Play("coin_state");
    }

    public void score_and_rejim_load()
    {
        int score = 0;

        switch (gmdb.rejim)
        {
            case 1:
                score = gmdb.classic_best_score;
                rejim_t.text = "► CLASSIC ◄";
                break;
            case 2:
                score = gmdb.rain_best_score;
                rejim_t.text = "► SPIKES RAIN ◄";
                break;
        }

        best_score_t.text = "B-SCORE: " + score;
    }
}
