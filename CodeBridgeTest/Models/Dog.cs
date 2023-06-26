using System.ComponentModel.DataAnnotations;

namespace CodeBridgeTest.Model
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        [Range(0, int.MaxValue)]
        public float TailLength { get; set; }

        [Range(0, int.MaxValue)]
        public float Weight { get; set; }
    }
}