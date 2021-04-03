using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopulateAndDeleteViewScript : MonoBehaviour
{
    public InitializerScript listItemPrefab2;
    public ParsingScript obj1;
    public Transform mshobeli_gameobject;
    List<GameObject> arr_of_infos = new List<GameObject>();

    public void PopulateView()
    {
        for (int i = 0; i < obj1.playerInfos_list.Count; i++)
        {
            var newElementView = Instantiate(listItemPrefab2, mshobeli_gameobject);
            arr_of_infos.Add(newElementView.gameObject);
            newElementView.initializer(obj1.playerInfos_list[i]);
        }
    }
    public void DeleteView()
    {
        if ( arr_of_infos.Count> 0){
            for (int i = arr_of_infos.Count - 1; i >= 0; i--)
            {
                Destroy(arr_of_infos[i]);

            }
            arr_of_infos.Clear();
        }

    }

    public void PopulateViewForCloned(List<PlayerInfo> playerInfos_list_cloned)
    {
        for (int i = 0; i < playerInfos_list_cloned.Count; i++)
        {
            var newElementView = Instantiate(listItemPrefab2, mshobeli_gameobject);
            arr_of_infos.Add(newElementView.gameObject);
            newElementView.initializer(playerInfos_list_cloned[i]);
        }
    }
}
