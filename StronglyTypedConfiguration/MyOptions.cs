namespace StronglyTypedConfiguration
{
    public class MyOptions {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public BazOptions Baz { get; set; }

        public class BazOptions {
            public string Faz { get; set; }
        }
    }
    
}