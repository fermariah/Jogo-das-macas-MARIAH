using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDelegate : MonoBehaviour
{
    public delegate void AppleCollectedHandler();
    public static event AppleCollectedHandler OnAppleCollected;

    public static void AppleCollected()
    {
        OnAppleCollected?.Invoke();
    }
}
