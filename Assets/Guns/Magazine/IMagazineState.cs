using System.Collections;
using System;

public interface IMagazineState
{
    void Shoot(Magazine magazine);
    IEnumerator Reload(Magazine magazine);
}

