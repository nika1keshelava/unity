using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotGlexuriAbstractScript : MonoBehaviour
{
    public Text mytext;
    public int temp;
    


    public void initializer(int temp)
    {
        mytext.text = temp.ToString();
        
    }

    
}
