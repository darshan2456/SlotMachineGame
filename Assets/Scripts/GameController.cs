using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private LeverController leverController;
    [SerializeField] private ReelController[] reels;

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

        foreach (ReelController reel in reels)
        {
            int rand = randomGenerator.GenerateSymbol();
            reel.startSpin(rand);
        }
    }
}