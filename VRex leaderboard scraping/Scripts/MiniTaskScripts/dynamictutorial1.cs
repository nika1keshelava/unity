using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dynamictutorial1 : MonoBehaviour
{
    public NotGlexuriAbstractScript listItemPrefab;
  
    public Transform listItemHolder;
    List<GameObject> arr_of_numbers = new List<GameObject>();


    public void PopulateView(int temp)
    {
        for (int i = 0; i < temp; i++)
        {

            var newElementView = Instantiate(listItemPrefab, listItemHolder);

            arr_of_numbers.Add(newElementView.gameObject);
            newElementView.initializer(i);
            



        }


    }
    public void DeleteView()
    {
        for (int i = arr_of_numbers.Count - 1; i >= 0; i--)
        {
            Destroy(arr_of_numbers[i]);
            
        }
        arr_of_numbers.Clear();
    }
}
