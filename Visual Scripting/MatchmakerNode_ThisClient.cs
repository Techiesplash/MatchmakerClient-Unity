using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Matchmaker.Visual_Scripting
{
    [UnitTitle("This Client's ID")]
    [UnitSubtitle("Matchmaker API")]
    [UnitCategory("Matchmaking")]
    [TypeIcon(typeof(DummyScript_Icon))]
    public class MatchmakerNode_ThisClient : Unit, IMatchmaker
    {
        [DoNotSerialize] // No need to serialize ports
        public ValueOutput get;

        protected override void Definition()
        {
            get = ValueOutput<int>("get", (flow) =>
            {
                if (IMatchmaker.listClient == null)
                {
                    Debug.LogError("Error in This Client's ID node: listClient is null!");
                    return 0;
                }

                return IMatchmaker.listClient.myId;
            });
        }
    }
}