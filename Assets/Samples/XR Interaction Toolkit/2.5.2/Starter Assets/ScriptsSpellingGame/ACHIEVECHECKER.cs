using UnityEngine;

public class SpellingChecker : MonoBehaviour
{
    [SerializeField] private SnapZoneTracker[] snapZones; // Now shows in Inspector
    public string correctWord = "ACHIEVE";

    public void CheckSpelling()
    {
        string userWord = "";

        foreach (SnapZoneTracker zone in snapZones)
        {
            if (zone.currentLetter != "")
                userWord += zone.currentLetter[0];
            else
                userWord += "_";
        }

        if (userWord == correctWord)
        {
            Debug.Log("✅ Correct! Word: " + userWord);
        }
        else
        {
            Debug.Log("❌ Incorrect. You wrote: " + userWord);
        }
    }
}

