using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class EnemyManager : MonoBehaviour
    {
        public List<EnemyController> Enemies { get; private set; }
        public int NumberOfEnemiesTotal { get; private set; }
        public int NumberOfEnemiesRemaining => Enemies.Count;

        public GameObject objectToDeactivate; // The GameObject you want to deactivate
        public GameObject objectToActivate;   // The GameObject you want to activate

        void Awake()
        {
            Enemies = new List<EnemyController>();
        }

        public void RegisterEnemy(EnemyController enemy)
        {
            Enemies.Add(enemy);
            NumberOfEnemiesTotal++;
        }

        public void UnregisterEnemy(EnemyController enemyKilled)
        {
            int enemiesRemainingNotification = NumberOfEnemiesRemaining - 1;

            EnemyKillEvent evt = Events.EnemyKillEvent;
            evt.Enemy = enemyKilled.gameObject;
            evt.RemainingEnemyCount = enemiesRemainingNotification;
            EventManager.Broadcast(evt);

            // Remove the enemy from the list
            Enemies.Remove(enemyKilled);

            // Deactivate the object when only 1 enemy remains
            if (NumberOfEnemiesRemaining == 1 && objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false); // Deactivate the object
            }

            // Reactivate the object when no enemies remain
            if (NumberOfEnemiesRemaining == 0 && objectToActivate != null)
            {
                objectToActivate.SetActive(true); // Activate the object
            }
        }
    }
}
