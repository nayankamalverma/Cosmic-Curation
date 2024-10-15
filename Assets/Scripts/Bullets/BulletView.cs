using System.Collections;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        public void SetController(BulletController bulletController) => this.bulletController = bulletController;

        private void Update() => bulletController?.UpdateBulletMotion();

        private void OnTriggerEnter2D(Collider2D collision) => bulletController?.OnBulletEnteredTrigger(collision.gameObject);

        public void DisableAfterSomeTime()
        {
            StartCoroutine(DisableWhenNotUsed());
        }

        private IEnumerator DisableWhenNotUsed()
        {
            yield return new WaitForSeconds(5f);
            GameService.Instance.GetPlayerService().ReturnBulletToPool(bulletController);
            gameObject.SetActive(false);
        }
    }
}