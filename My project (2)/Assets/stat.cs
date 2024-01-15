using DTT.MinigameMemory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stat : MonoBehaviour
{
    private static MemoryGameManager _memoryGameManagerCache;


    public static MemoryGameSettings memoryGameSettings;

    /// <summary>
    /// Get MemoryGameManager script from scene.
    /// </summary>
    /// <returns>Card game manager <see cref="MemoryGameManager"/>.</returns>
    public MemoryGameManager GetCardObject()
    {
        if (_memoryGameManagerCache == null)
        {
            _memoryGameManagerCache = FindObjectOfType<MemoryGameManager>();

            if (_memoryGameManagerCache == null)
            {
                Debug.LogError("MemoryGameManager not found in the scene.");
            }
        }

        return _memoryGameManagerCache;
    }

    // Update is called once per frame
    void Update()
    {
        if (_memoryGameManagerCache == null)
        {
            _memoryGameManagerCache = GetCardObject();
            _memoryGameManagerCache.StartGame(memoryGameSettings);
        }
    }
}
