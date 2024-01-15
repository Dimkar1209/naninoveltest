using DTT.MinigameMemory;
using Naninovel;
using System.Threading.Tasks;
using UnityEngine;

[InitializeAtRuntime(5)]
public class MemoryGameService : IEngineService
{
    public MemoryGameService()
    {
    }

    public UniTask InitializeServiceAsync()
    {
        return UniTask.CompletedTask;
    }

    public void ResetService()
    {

    }

    public void DestroyService()
    {

    }

    public async UniTask<MemoryGameResults> StartMiniGameAsync(MemoryGameManager memoryGameManager, MemoryGameSettings memoryGameSettings)
    {
        if (memoryGameManager == null || memoryGameSettings == null)
        {
            Debug.LogError("MemoryGameManager is null. MemoryGameService");
        }

        var tcs = new TaskCompletionSource<MemoryGameResults>();

        void OnGameFinished(MemoryGameResults results)
        {
            tcs.TrySetResult(results);
            memoryGameManager.Finish -= OnGameFinished;
        }

        memoryGameManager.Finish += OnGameFinished;
        memoryGameManager.StartGame(memoryGameSettings);

        return await tcs.Task;
    }

}