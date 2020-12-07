using UnityEngine;

[CreateAssetMenu(menuName = "Localization/LocalString")]
public class LocalString : ScriptableObject
{
	// Our array of languages, each with a name and content field
	// To add languages, increase the size of the array in the inspector. Then you can fill in the newly added language items
	[SerializeField]
	LocalStringWrapper[] languages;

	public string Content()
	{
		// Loops through the array, checks to see if any of the language names match that set in the ChangeCurrentLanguage script
		for (int i = 0; i < languages.Length; i++)
		{
			//Debug.Log("lsw i language: " + languages[i].language);
			if (ChangeCurrentLanguage.currentLanguage == languages[i].language)
			{
				// Returns the content field (string) of the appropriate language
				return languages[i].content;
			}
		}
		return "Language not found.";
	}

}

// Field for name (for matching) and field for content (that matches that language)
[System.Serializable]
public class LocalStringWrapper
{
	public string language;
	public string content;
}