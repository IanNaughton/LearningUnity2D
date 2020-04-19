using System.Collections;
using System;

public interface IMagazineState
{
    void Init(Magazine magazine);
    void Shoot(Magazine magazine);
    IEnumerator Reload(Magazine magazine);
}

