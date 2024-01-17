using Naninovel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestLogTriggers : MonoBehaviour
{
    public GameObject ReceivePackageQuest;
    public GameObject OpenPackageQuest;
    public GameObject JaneGoneQuest;
    public GameObject JohnOfficeQuest;
    public GameObject SuperChargeQuestEnd;

    private Dictionary<string, GameObject> questDictionary;

    public void UpdateQuest()
    {
        var varManager = Engine.GetService<ICustomVariableManager>();
        var variables = varManager.GetAllVariables();
        
        questDictionary = new Dictionary<string, GameObject>()
        {
            {"JanePackage", ReceivePackageQuest},
            {"OpenPackage", OpenPackageQuest},
            {"JaneGone", JaneGoneQuest},
            {"JohnAndJane", JohnOfficeQuest},
            {"FinalEnd", SuperChargeQuestEnd},
        };

        questDictionary.Values.ToList().ForEach(questGameObject => questGameObject.SetActive(false));

        foreach (var item in variables)
        {
            setGameObjectActive(item);
        }
    }

    private void setGameObjectActive(CustomVariable customVariable)
    {
        // Check if the existing variable name corresponds to a quest
        if (questDictionary.TryGetValue(customVariable.Value, out GameObject questGameObject))
        {
            switch (customVariable.Value)
            {
                case "JanePackage":
                    questGameObject.SetActive(true);
                    break;
                case "OpenPackage":
                    questGameObject.SetActive(true);
                    break;
                case "JaneGone":
                    questGameObject.SetActive(true);
                    break;
                case "JohnAndJane":
                    questGameObject.SetActive(true);
                    break;
                case "FinalEnd":
                    questGameObject.SetActive(true);
                    break;
            }

        }
    }
}
