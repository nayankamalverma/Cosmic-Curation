using CosmicCuration.Utilities;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace CosmicCuration.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;

        public EnemyPool(EnemyView enemyPrefab, EnemyData enemyData)
        {
            this.enemyPrefab = enemyPrefab;
            this.enemyData = enemyData;
        }

        public EnemyController GetEnemy() => GetItem();

        protected override EnemyController CreateItem() => new EnemyController(enemyPrefab, enemyData);

        public class PooledEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }
    }
}
