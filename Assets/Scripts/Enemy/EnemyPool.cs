using CosmicCuration.Bullets;
using static CosmicCuration.Bullets.BulletPool;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
	public class EnemyPool
	{
		private Transform enemyParent;

        private EnemyView enemyView;
		private EnemyScriptableObject enemyScriptableObject;
		private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();

		public EnemyPool(EnemyView enemyView, EnemyScriptableObject enemyScriptableObject, Transform enemyParent) {
			this.enemyView = enemyView;
			this.enemyScriptableObject = enemyScriptableObject;
			this.enemyParent = enemyParent;	
		}

		public EnemyController GetEnemy()
		{
			if (pooledEnemies.Count > 0)
			{
				PooledEnemy enemy = pooledEnemies.Find(enemy => !enemy.isUsed);
                if(enemy != null){
                    enemy.isUsed = true;
                    return enemy.Enemy;
                }
			}
			return CreateNewPooledEnemy();
		}

        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
			pooledEnemy.Enemy = new EnemyController(enemyView,enemyScriptableObject.enemyData, enemyParent);
			pooledEnemy.isUsed = true;
			pooledEnemies.Add(pooledEnemy);

			return pooledEnemy.Enemy;
        }

		public void ReturnEnemyToPool(EnemyController returnedEnemy)
		{
			PooledEnemy enemy =  pooledEnemies.Find(enemy=> enemy.Enemy == returnedEnemy);
			enemy.isUsed = false;
		}


        public class PooledEnemy
		{
			public EnemyController Enemy;
			public bool isUsed;
		}
	}
}