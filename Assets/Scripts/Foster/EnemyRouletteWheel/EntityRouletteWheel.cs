using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zzzNico.Entities;

public abstract class EntityRouletteWheel
{
    public EntityRouletteWheel(EntityModel _model)
    {

        CreateRouletteWheel();
    }

    public abstract void CreateRouletteWheel();
}
