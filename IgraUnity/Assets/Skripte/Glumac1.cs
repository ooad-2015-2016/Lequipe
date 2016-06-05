using UnityEngine;
using System.Collections;

public class Glumac1 : Glumac
{

    public override void Ubrzaj()
    {
        brzina += 0.1f;
    }

    protected override void Start()
    {
        base.Start();
        base.vjerovatnoca = 0.987f;
    }


    public override bool Gotov()
    {
        return transform.position.y < downConstraint;
    }
}
