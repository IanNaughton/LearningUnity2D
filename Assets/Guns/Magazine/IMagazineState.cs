using System.Collections;


public interface IMagazineState
{
    void Shoot(Magazine magazine);
    IEnumerator Reload(Magazine magazine);
}

