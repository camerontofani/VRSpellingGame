using UnityEngine;
using TMPro;

public class SpellChecker : MonoBehaviour
{
    public SnapZoneTracker[] snapZones; // Assign in Inspector
    public string targetWord = "ACHIEVE"; // Editable per object

    public void CheckSpelling()
    {
        if (!gameObject.activeInHierarchy)
            return; // Don't run if this object is inactive

        string userWord = "";

        foreach (SnapZoneTracker zone in snapZones)
        {
            userWord += zone.currentLetter.ToUpper();
        }

        Debug.Log("User spelled: " + userWord + " (expected: " + targetWord + ")");

        if (userWord == targetWord.ToUpper())
        {
            Debug.Log("Correct! You spelled " + targetWord + ".");
        }
        else
        {
            Debug.Log("Incorrect. Try again.");
        }
    }
}




