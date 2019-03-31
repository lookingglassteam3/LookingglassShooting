using System;
using LooklingGlassShooting.Models;
using UnityEngine;

public class GlobalRegistory : MonoBehaviour
{
    public static SeasonFormat[] PlayerSeasons;

    public static float RoundTime = 60.0f;

    public GlobalRegistory()
    {
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }

    public static void SetSeasons(SeasonFormat player1Season, SeasonFormat player2Season)
    {
        PlayerSeasons = new SeasonFormat[]{
            player1Season,
            player2Season,
        };
        
    }

    public static float GetRoundTime()
    {
        return RoundTime;
    }

    public static SeasonFormat[] GetSeasons()
    {
        return PlayerSeasons;
    }
}
