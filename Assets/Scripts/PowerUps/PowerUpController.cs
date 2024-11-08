using UnityEngine;
using CosmicCuration.Player;
using System.Threading.Tasks;

namespace CosmicCuration.PowerUps
{
    public class PowerUpController : IPowerUp
    {
        private PowerUpView powerUpView;
        private float activeDuration;
        private bool isActive;

        public PowerUpController(PowerUpData powerUpData)
        {
            powerUpView = Object.Instantiate(powerUpData.powerUpPrefab);
            powerUpView.SetController(this);
            activeDuration = powerUpData.activeDuration;
        }

        public void Configure(Vector2 spawnPosition)
        {
            isActive = false;
            powerUpView.transform.position = spawnPosition;
            powerUpView.gameObject.SetActive(true);
            powerUpView.SetView(true);
            powerUpView.DisableWhenNotUsed(5f);
        }

        public void StartTimer()
        {
            if (isActive)
            {
                powerUpView.DisableAfterSomeTime(activeDuration);
            }
        }

        public void PowerUpTriggerEntered(GameObject collidedObject)
        {
            if (collidedObject.GetComponent<PlayerView>() != null)
                Activate();
        }

        public virtual void Activate()
        {
            isActive = true;
            StartTimer();
        }

        public virtual void Deactivate()
        {
            isActive = false;
            powerUpView.gameObject.SetActive(false);
            GameService.Instance.GetPowerUpService().ReturnPowerUpToPool(this);
        }
    } 
}