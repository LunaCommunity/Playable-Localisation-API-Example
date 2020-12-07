using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeCurrentLanguage : MonoBehaviour
{
    // Store the language code given by the API
    private string lang;

    // Becomes equal to the desired language, singular value to be accessed by other scripts. 
    public static string currentLanguage;

    // Stores the Content method from LocalString.cs 
    public static Action LanguageChange;

    // For debugging language codes (Not necessary)
    public Text langCodeLog;

    void Start()
    {
        // Need to preprocess this to only run in Luna, as the API does not work in Unity.
#if UNITY_LUNA
        lang = Luna.Unity.Playable.GetPreferredLanguage();
#endif
        // Default value assigned for Unity build
#if !UNITY_LUNA
        lang = "en-gb";
#endif
        //Debugging - Display language code on screen (Not necessary)
        langCodeLog.text = "Language Code: " + lang;

        // Language codes can differ in casing depending on the device, setting the code to lowercase here eliminates that problem for comparisons
        lang = lang.ToLower();

        // Match language code to appropriate language name, set lang to be that name
        switch (lang)
        {
            case "en-gb":
                lang = "English";
                break;
            case "it-it":
                lang = "Italian";
                break;
            case "fr-fr":
                lang = "French";
                break;
        }

        ChangeLanguage(lang);
    }

    public void ChangeLanguage(string lang)
    {
        //Debug.Log(lang);

        // Sets the public variable to that name so the Scriptable Object can access it
        currentLanguage = lang;

        // Runs the methods (on each text object with the UseLocalString script on it) that sets the text to be the appropriate contents from the Scriptable Object instances 
        LanguageChange();
    }
}
