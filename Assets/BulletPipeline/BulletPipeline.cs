using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPipeline : MonoBehaviour
{
    public List<PipelineComponentBase> PipelineComponents;

    public void Fire(Bullet bullet)
    {
        foreach(PipelineComponentBase component in PipelineComponents)
        {
            component.Fire(bullet);
        }
    }
}
