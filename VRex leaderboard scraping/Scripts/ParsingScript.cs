using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using HtmlAgilityPack;
using System.Net;
using System.Text;

public class ParsingScript : MonoBehaviour
{
    public List<PlayerInfo> playerInfos_list = new List<PlayerInfo>();
    


    public List<string> only_names = new List<string>();
    public List<string> only_scores = new List<string>();
    public List<string> only_games = new List<string>();
    public List<string> full_info_list = new List<string>();

    void Start()
    {
        string data = "";
        string urlAddress = "http://interest.vrexbox.com/amz/static/";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (String.IsNullOrWhiteSpace(response.CharacterSet))
                readStream = new StreamReader(receiveStream);
            else
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

            data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

        }
        Debug.Log(data);


        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(data);








        foreach (HtmlNode table in htmlDoc.DocumentNode.SelectNodes("//table"))
        {
            foreach (HtmlNode tbody in table.SelectNodes("//tbody"))
            {
                Debug.Log("Found: " + table.Id);
                foreach (HtmlNode row in tbody.SelectNodes("tr"))
                {
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        full_info_list.Add(cell.InnerText);

                        Debug.Log("cell: " + cell.InnerText);
                    }
                }
            }
        }

        //full info
        foreach (string element in full_info_list)
        {
            Debug.Log("player__name " + element);
        }



        for (int i = 0; i < full_info_list.Count; i += 3)
        {
            PlayerInfo obj = new PlayerInfo();
            only_names.Add(full_info_list[i]);

            obj.name = full_info_list[i];

            int.TryParse(full_info_list[i + 1], out obj.score);

            string[] subs = full_info_list[i + 2].Split(',');
            foreach (var sub in subs)
            {
                obj.games_played.Add(sub);
            }
            playerInfos_list.Add(obj);
        }


        foreach (string el in only_names)
        {
            Debug.Log("only name " + el);
        }





        //only scores
        for (int i = 1; i < full_info_list.Count + 1; i += 3)
        {
            only_scores.Add(full_info_list[i]);
        }
        int x = 0;
        foreach (string el in only_scores)
        {
            Debug.Log("only score of " + full_info_list[x] + ": " + el);
            x += 3;
        }

        //only games
        for (int i = 2; i < full_info_list.Count + 2; i += 3)
        {
            only_games.Add(full_info_list[i]);
        }
        int j = 0;
        foreach (string el in only_games)
        {
            Debug.Log("only games of " + full_info_list[j] + ": " + el);
            j += 3;
        }

        ParsingHasFinished();

        
    }
    private void ParsingHasFinished()
    {
        Debug.Log("Parsing Has Finished");
    }
}





