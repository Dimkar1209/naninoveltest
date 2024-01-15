using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using DTT.MinigameMemory;
using Naninovel;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

[CommandAlias("CardGameCommand")]
public class CardGameCommand : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var memoryGameData = GameObject.FindObjectOfType<MemoryGameTrigger>();
        var customService = Engine.GetService<MemoryGameService>();

        var varManager = Engine.GetService<ICustomVariableManager>();
        var uiManager = Engine.GetService<IUIManager>();

        var cardResult = await customService.StartMiniGameAsync(memoryGameData.MemoryGameManagerCache, memoryGameData.MemoryGameSettings);
        varManager.SetVariableValue("CardGameTurns", cardResult.amountOfTurns.ToString());
    }
}