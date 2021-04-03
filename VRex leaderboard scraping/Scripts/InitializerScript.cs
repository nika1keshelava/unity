using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializerScript : MonoBehaviour
{
    public Text NameText;
    public Text ScoreText;
    public Text GamesPlayedText;



    public void initializer(PlayerInfo info)
    {
        NameText.text = info.name;
        ScoreText.text = info.score.ToString();

        string GamesPlayedtemporary = " ";
        foreach(string element in info.games_played)
        {
            GamesPlayedtemporary += element + ", ";
            GamesPlayedText.text = GamesPlayedtemporary;
        }
      }
}
