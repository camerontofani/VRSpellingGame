using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    public List<GameObject> wordObjects;
    private int currentWordIndex = -1;

    void Start()
    {
        foreach (GameObject word in wordObjects)
        {
            word.SetActive(false);
        }

        LoadNextWord();
    }

    public void LoadNextWord()
    {
        // Hide and reset current word
        if (currentWordIndex >= 0 && currentWordIndex < wordObjects.Count)
        {
            GameObject currentWord = wordObjects[currentWordIndex];
            ScrambleThenDrop std = currentWord.GetComponent<ScrambleThenDrop>();
            if (std != null)
            {
                std.ResetLetters();
            }
            currentWord.SetActive(false);
        }

        // Next word
        currentWordIndex = (currentWordIndex + 1) % wordObjects.Count;

        // Show and drop
        GameObject newWord = wordObjects[currentWordIndex];
        newWord.SetActive(true);
        ScrambleThenDrop newStd = newWord.GetComponent<ScrambleThenDrop>();
        if (newStd != null)
        {
            newStd.StartDropSequence();
        }
    }
}


