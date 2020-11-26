using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipelineComponentBase : MonoBehaviour
{
    public abstract void Fire(Bullet bullet);
}
