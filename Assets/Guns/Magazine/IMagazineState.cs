using System.Collections;

public interface IMagazineState
{
    void Init(Magazine magazine);

    void Shoot(Magazine magazine);

    IEnumerator Reload(Magazine magazine);
}