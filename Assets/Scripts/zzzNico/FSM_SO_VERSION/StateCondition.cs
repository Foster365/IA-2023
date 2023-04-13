using UnityEngine;
using zzzNico.Entities;

namespace zzzNico.FSM_SO_VERSION
{

    public abstract class StateCondition : ScriptableObject
    {
        public abstract bool CompleteCondition(EntityModel model);
    }
}