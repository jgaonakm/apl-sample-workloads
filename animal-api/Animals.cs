using System.Runtime.Serialization;

[DataContract(Name = "animals")]
public class Animals(IList<Animal> values, int count)
{
    [DataMember(Name ="count")]
    public int Count {get; private set;} = count;

    [DataMember(Name = "values")]
    public IList<Animal> Values { get; private set; } = values;
}