using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndButton : MonoBehaviour
{
    public NotGlexuriAbstractScript obj;
    public dynamictutorial1 buttonActivator;
    private int temp;
    public void OnClickSpawnElements()
    {
        buttonActivator.DeleteView();
        buttonActivator.PopulateView(temp);

    }

    public void Text_Changed(string newText)
    {
        temp = int.Parse(newText);
        
    }
}
