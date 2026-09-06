using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class PopupController : MonoBehaviour
{

    [SerializeField] private GameController gameController;


    public void Play()
    {
        gameObject.SetActive(false);

        gameController.StartGame();
    }
}
