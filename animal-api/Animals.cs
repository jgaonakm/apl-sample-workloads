using System.Runtime.Serialization;

[DataContract(Name = "animals")]
public class Animals(IList<Animal> values)
{
    [DataMember(Name = "set")]
    public IList<Animal> Set { get; internal set; } = values;
}