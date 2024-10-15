using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletPool bulletPool;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject, Transform bulletParents)
        {
            bulletPool =  new BulletPool(bulletPrefab, bulletScriptableObject, bulletParents);
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPool);
           
        }

        public void ReturnBulletToPool(BulletController returnedBullet)=> bulletPool.ReturnToBulletPool(returnedBullet);

        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();

        
        
    } 
}