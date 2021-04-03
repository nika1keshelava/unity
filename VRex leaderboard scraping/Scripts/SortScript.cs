using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortScript : MonoBehaviour
{
    public ParsingScript obj1;
    public PopulateAndDeleteViewScript obj2;
    public List<PlayerInfo> playerInfos_list_cloned;
    public void CloneList()
    {
        playerInfos_list_cloned = new List<PlayerInfo>(obj1.playerInfos_list);
    }
    public int SortInfoByScoreAscending(PlayerInfo info1, PlayerInfo info2)
    {
        if (info1.score < info2.score)
        {
            return -1;
        }
        else if (info1.score > info2.score)
        {
            return 1;
        }
        return 0;
    }

    public void SortOurList()
    {
        CloneList();
        playerInfos_list_cloned.Sort(SortInfoByScoreAscending);
    }
    public void OnClickSortButton()
    {
        SortOurList();
        obj2.DeleteView();
        obj2.PopulateViewForCloned(playerInfos_list_cloned);
    }



    public int SortInfoByScoreDescending(PlayerInfo info1, PlayerInfo info2)
    {
        if (info1.score < info2.score)
        {
            return 1;
        }
        else if (info1.score > info2.score)
        {
            return -1;
        }
        return 0;
    }
    public void SortOurListDescending()
    {
        CloneList();
        playerInfos_list_cloned.Sort(SortInfoByScoreDescending);
    }

    public void OnClickSortButtonDescending()
    {
        SortOurListDescending();
        obj2.DeleteView();
        obj2.PopulateViewForCloned(playerInfos_list_cloned);
    }

    
}
