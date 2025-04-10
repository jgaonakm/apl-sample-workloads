using System.Runtime.Serialization;

[DataContract(Name = "animals")]
public class Animals(IList<Animal> values)
{
    [DataMember(Name = "values")]
    public IList<Animal> Values { get; internal set; } = values;
}