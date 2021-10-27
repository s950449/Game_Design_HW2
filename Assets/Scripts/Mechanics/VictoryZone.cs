using Platformer.Gameplay;
using UnityEngine;
using Platformer.Model;
using static Platformer.Core.Simulation;
namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            PlatformerModel model = GetModel<PlatformerModel>();
            bool canWin = model.player.animator.GetBool("canWin");
            if (p != null && canWin)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
            }
        }
    }
}