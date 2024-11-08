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

        public void SetController(PowerUpController controller) => powerUpController = controller;

        private void OnTriggerEnter2D(Collider2D collision) => powerUpController?.PowerUpTriggerEntered(collision.gameObject);

        public void SetView(bool set)
        {
            sprite.enabled = set;
            collider.enabled = set;
        }

        public void DisableAfterSomeTime(float delay)
        {
            SetView(false);
            StartCoroutine(DisableWhenNotUsed());
        }
        private IEnumerator DisableWhenNotUsed()
        {
            yield return new WaitForSeconds(5f);
            powerUpController.Deactivate();
        }
    } 
}