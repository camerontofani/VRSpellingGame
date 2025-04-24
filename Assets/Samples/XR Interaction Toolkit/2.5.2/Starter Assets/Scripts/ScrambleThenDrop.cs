using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleThenDrop : MonoBehaviour
{
    public List<Transform> letterBlocks;
    public float forwardShift = -1f;      // Small push forward toward table
    public float delayBeforeDrop = 1f;    // How long to wait before dropping

    void Start()
    {
        StartCoroutine(ScrambleAndDrop());
    }

    IEnumerator ScrambleAndDrop()
    {
        // Step 1: Scramble the Z positions
        List<float> zPositions = new List<float>();
        foreach (Transform letter in letterBlocks)
        {
            zPositions.Add(letter.localPosition.z);
        }

        for (int i = 0; i < zPositions.Count; i++)
        {
            float temp = zPositions[i];
            int randIndex = Random.Range(i, zPositions.Count);
            zPositions[i] = zPositions[randIndex];
            zPositions[randIndex] = temp;
        }

        for (int i = 0; i < letterBlocks.Count; i++)
        {
            Vector3 pos = letterBlocks[i].localPosition;
            pos.z = zPositions[i];
            letterBlocks[i].localPosition = pos;
        }

        // Step 2: Wait a second
        yield return new WaitForSeconds(0.5f);

        // Step 3: Smoothly move all blocks forward
        for (int i = 0; i < letterBlocks.Count; i++)
        {
            StartCoroutine(SmoothMove(letterBlocks[i], forwardShift, 0.5f)); // 0.5 seconds
        }

        // Step 4: Wait a bit more
        yield return new WaitForSeconds(delayBeforeDrop);

        // Step 5: Drop the blocks (turn gravity back on)
        foreach (var letter in letterBlocks)
        {
            Rigidbody rb = letter.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
    }

    IEnumerator SmoothMove(Transform block, float shiftZ, float duration)
    {
        Vector3 startPos = block.position;
        Vector3 endPos = startPos + new Vector3(0, 0, shiftZ);

        float elapsed = 0f;
        while (elapsed < duration)
        {
            block.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        block.position = endPos; // snap to final position
    }
}
