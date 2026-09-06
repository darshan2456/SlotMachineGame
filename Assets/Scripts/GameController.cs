using UnityEngine;
using System.Collections;
using System;
using NUnit.Framework.Interfaces;

public class GameController : MonoBehaviour
{
    [SerializeField] private LeverController leverController;
    [SerializeField] private ReelController[] reels;
    private int[] results;
    [SerializeField] private RandomGenerator randomGenerator;

    public void StartGame()
    {
        StartCoroutine(GameSequence());
    }

    public void RetryGame()
    {
        leverController.ResetLever();

        StartGame();
    }

    private IEnumerator GameSequence()
    {
        // Wait before pulling lever
        yield return new WaitForSeconds(1f);

        leverController.PullLever();

        // Wait after pulling lever
        yield return new WaitForSeconds(0.5f);

        results = new int[reels.Length];

        for (int i = 0; i < reels.Length; i++)
        {
            results[i] = randomGenerator.GenerateSymbol();

            reels[i].startSpin(results[i]);
        }

        yield return new WaitUntil(AllReelsStopped);

        CheckWin();
    }


    private bool AllReelsStopped()
    {
        foreach(ReelController reel in reels)
        {
            if (reel.isSpinning())
            {
                return false;
            }
        }

        return true;
    }

    private void CheckWin()
    {
        if (results[0] == results[1] && results[1] == results[2])
        {
            Debug.Log("You Win!!");
        }
        else
        {
            Debug.Log("You Lose");
        }
    }
}