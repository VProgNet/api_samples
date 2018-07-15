using AwesomeSauce.Interfaces;

namespace AwesomeSauce.Components
{
    public class ComponentB : IComponent
    {
        public string Name {get; set;} = nameof(ComponentB);
    }
}