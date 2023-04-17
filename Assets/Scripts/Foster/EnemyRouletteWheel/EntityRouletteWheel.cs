using zzzNico.Entities;

namespace Foster.EnemyRouletteWheel
{
    public abstract class EntityRouletteWheel
    {
        public EntityRouletteWheel(EntityModel _model)
        {

            CreateRouletteWheel();
        }

        public abstract void CreateRouletteWheel();
    }
}
