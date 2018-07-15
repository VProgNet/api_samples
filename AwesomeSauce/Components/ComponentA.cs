using AwesomeSauce.Interfaces;

namespace AwesomeSauce.Components
{
    public class ComponentA
    {
        private readonly IComponent _componentB;

        public ComponentA(IComponent componentB){
            _componentB = componentB;
        }

    }
}