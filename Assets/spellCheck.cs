using UnityEngine;

public class SpellChecker : MonoBehaviour
{
    public SnapZoneTracker[] snapZones; // Assign in Inspector, left to right
    private readonly string targetWord = "ACHIEVE";

    public void CheckSpelling()
    {
        string userWord = "";

        foreach (SnapZoneTracker zone in snapZones)
        {
            userWord += zone.currentLetter.ToUpper(); // Ensures consistency
        }

        if (userWord == targetWord)
        {
            Debug.Log("Correct! You spelled ACHIEVE.");
        }
        else
        {
            Debug.Log("Incorrect. Try again.");
        }
    }
}


