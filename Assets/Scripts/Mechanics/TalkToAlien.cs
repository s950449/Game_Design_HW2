using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using Platformer.UI;
namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a TalkToAlien, usually used to end the current game level.
    /// </summary>

    public class TalkToAlien : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            PlatformerModel model = Simulation.GetModel<PlatformerModel>();
            if (p != null)
            {
                model.player.animator.SetBool("canWin", true);
                model.player.canwin = true;
            }
        }
    }
}