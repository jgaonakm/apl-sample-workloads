using System.Runtime.Serialization;

[DataContract]
public class Animal(int id, double? lat, double? lng, string phylum, string className, string order, string family, string genus, string? subnegnus, string specie,
    string country, string? state, string? city, string? area, string source, string biologicalGroup)
{
    [DataMember]
    public int Id { get; internal set; } = id;
    [DataMember]
    public double? Lat { get; internal set; } = lat;
    [DataMember]
    public double? Long { get; internal set; } = lng;
    [DataMember]
    public string Phylum { get; internal set; } = phylum;
    [DataMember]
    public string Class { get; internal set; } = className;
    [DataMember]
    public string Order { get; internal set; } = order;
    [DataMember]
    public string Family { get; internal set; } = family;
    [DataMember]
    public string Genus { get; internal set; } = genus;
    [DataMember]
    public string? Subgenus { get; internal set; } = subnegnus;
    [DataMember]
    public string Specie { get; internal set; } = specie;
    [DataMember]
    public string Country { get; internal set; } = country;
    [DataMember]
    public string? State { get; internal set; } = state;
    [DataMember]
    public string? City { get; internal set; } = city;
    [DataMember]
    public string? Area { get; internal set; } = area;
    [DataMember]
    public string Source { get; internal set; } = source;
    [DataMember]
    public string BiologicalGroup { get; internal set; } = biologicalGroup;
}