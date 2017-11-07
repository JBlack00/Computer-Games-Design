using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the player.
/// This script allows the player to move between scenes.
/// </summary>

public class DontDestroyOnLoad : MonoBehaviour
{
    public Transform Player;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
