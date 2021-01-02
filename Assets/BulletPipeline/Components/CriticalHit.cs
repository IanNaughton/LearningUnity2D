using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.BulletPipeline.Components
{
    /// <summary>
    /// Applies a critcal hit chance to a bullet
    /// </summary>
    public class CriticalHit : PipelineComponentBase
    {
        public int CritChance;
        public float CritDamage;
        public override void Fire(Bullet bullet)
        {
            Debug.Log("Rolling for critical...");
            var roll = UnityEngine.Random.Range(0, 100);
            if (roll <= CritChance)
            {
                Debug.Log("Critical hit! Setting damage values");
                bullet.Damage += (float)Math.Round((CritDamage * bullet.Damage));
                bullet.IsCriticalHit = true;
                Debug.Log("Values set!");
            }
        }
    }
}
