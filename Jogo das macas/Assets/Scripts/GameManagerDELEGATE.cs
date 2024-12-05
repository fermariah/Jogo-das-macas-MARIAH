using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDELEGATE: MonoBehaviour //classe de delegate para criar um evento acionado sempre que a ma�� � coletada
{
    public delegate void AppleCollectedHandler();
    public static event AppleCollectedHandler Coletou;

    public static void MacaColetada() //m�todo para definir a ma��o coletada
    {
        Coletou?.Invoke();
    }
}
