using AwesomeSauce.Interfaces;

namespace AwesomeSauce.Components
{
    public class ComponentC : IComponent
    {
        public string Name {get; set;} = nameof(ComponentC);
    }
}