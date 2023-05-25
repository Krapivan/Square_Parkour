using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_save : MonoBehaviour
{
    public game_db gmdb;
    public skin_db skdb;

    public void save()
    {
        //game
        PlayerPrefs.SetInt("start", gmdb.start);
        PlayerPrefs.SetInt("coin", gmdb.coin);
        PlayerPrefs.SetInt("rejim", gmdb.rejim);
        PlayerPrefs.SetInt("classic_best_score", gmdb.classic_best_score);
        PlayerPrefs.SetInt("rain_best_score", gmdb.rain_best_score);

        //skin
        PlayerPrefs.SetInt("skin_now", skdb.skin_now);

        for (int i = 0; i < skdb.skin_have.Length; i++)
        {
            PlayerPrefs.SetInt("skin_have_" + i, skdb.skin_have[i]);
        }

        PlayerPrefs.Save();
    }

    public void load()
    {
        //game
        gmdb.start = PlayerPrefs.GetInt("start");
        gmdb.coin = PlayerPrefs.GetInt("coin");
        gmdb.rejim = PlayerPrefs.GetInt("rejim");
        gmdb.classic_best_score = PlayerPrefs.GetInt("classic_best_score");
        gmdb.rain_best_score = PlayerPrefs.GetInt("rain_best_score");

        //skin
        skdb.skin_now = PlayerPrefs.GetInt("skin_now");

        for (int i = 0; i < skdb.skin_have.Length; i++)
        {
            skdb.skin_have[i] = PlayerPrefs.GetInt("skin_have_" + i);
        }

        if (gmdb.start == 0)
        {
            start_game();
        }
    }
    void start_game()
    {
        PlayerPrefs.DeleteAll();
        gmdb.rejim = 1;
        gmdb.start = 1;
        gmdb.coin = 0;

        gmdb.classic_best_score = 0;
        gmdb.rain_best_score = 0;

        skdb.skin_now = 1;
        skdb.skin_have[0] = 1;
        for (int i = 1; i < skdb.skin_have.Length; i++)
        {
            skdb.skin_have[i] = 0;
        }
        save();
        SceneManager.LoadScene("title");
    }
}
