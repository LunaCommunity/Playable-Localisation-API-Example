using UnityEngine;
using UnityEngine.UI;

public class UseLocalString : MonoBehaviour
{
    // The Text object you wish to alter 
    public Text myText;
    // The Scriptable Object instance you wish to pull strings from
    public LocalString myString;

    void SetText()
    {
        // Sets the text of the assigned object to be that of the Scriptable Object's content field
        myText.text = myString.Content();
    }
    // Assigning SetText method to the Action in ChangeCurrentLanguage.cs
    void OnEnable() { ChangeCurrentLanguage.LanguageChange += SetText; }

    // Unssigning SetText method to the Action in ChangeCurrentLanguage.cs
    void OnDisable() { ChangeCurrentLanguage.LanguageChange -= SetText; }
}
