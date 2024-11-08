using UnityEngine;
using System.Collections;

namespace CosmicCuration.PowerUps
{
    public class PowerUpView : MonoBehaviour
    {
        [SerializeField]
        private Collider2D collider;
        [SerializeField]
        private SpriteRenderer sprite;
        private PowerUpController powerUpController;
        private bool isPowerUp;

        public void SetController(PowerUpController controller) => powerUpController = controller;

        private void OnTriggerEnter2D(Collider2D collision) => powerUpController?.PowerUpTriggerEntered(collision.gameObject);

        public void SetView(bool set)
        {
            sprite.enabled = set;
            collider.enabled = set;
            isPowerUp = false;
        }

        public void DisableAfterSomeTime(float delay)
        {
            SetView(false);
            isPowerUp = true;
            StartCoroutine(DisableWhenPowerUpFinish(delay));
        }
        private IEnumerator DisableWhenPowerUpFinish(float delay)
        {
            yield return new WaitForSeconds(delay);
            powerUpController.Deactivate();
        }
        public IEnumerator DisableWhenNotUsed(float delay)
        {
            yield return new WaitForSeconds(delay);
            if(!isPowerUp) powerUpController.Deactivate();
        }
    } 
}