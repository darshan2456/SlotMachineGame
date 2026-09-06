using JetBrains.Annotations;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public int GenerateSymbol()
    {
        return Random.Range(0, 4);
    }

    public int[] GenerateResults(int numOfReels)
    {
        int[] results = new int[numOfReels];

        for(int i = 0; i < numOfReels; i++)
        {
            results[i] = GenerateSymbol();
        }

        return results;
    }
}
