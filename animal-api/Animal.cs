using System.Runtime.Serialization;

[DataContract(Name = "animal")]
public class Animal(int id, double? lat, double? lng, string phylum, string className, string order, string family, string genus, string? subnegnus, string specie,
    string country, string? state, string? city, string? area, string source, string biologicalGroup)
{
    [DataMember(Name = "id")]
    public int Id { get; internal set; } = id;
    [DataMember(Name = "lat")]
    public double? Lat { get; internal set; } = lat;
    [DataMember(Name = "lng")]
    public double? Long { get; internal set; } = lng;
    [DataMember(Name = "phylum")]
    public string Phylum { get; internal set; } = phylum;
    [DataMember(Name = "className")]
    public string Class { get; internal set; } = className;
    [DataMember(Name = "order")]
    public string Order { get; internal set; } = order;
    [DataMember(Name = "family")]
    public string Family { get; internal set; } = family;
    [DataMember(Name = "genus")]
    public string Genus { get; internal set; } = genus;
    [DataMember(Name = "subgenus")]
    public string? Subgenus { get; internal set; } = subnegnus;
    [DataMember(Name = "specie")]
    public string Specie { get; internal set; } = specie;
    [DataMember(Name = "country")]
    public string Country { get; internal set; } = country;
    [DataMember(Name = "state")]
    public string? State { get; internal set; } = state;
    [DataMember(Name = "city")]
    public string? City { get; internal set; } = city;
    [DataMember(Name = "area")]
    public string? Area { get; internal set; } = area;
    [DataMember(Name = "source")]
    public string Source { get; internal set; } = source;
    [DataMember(Name = "biologicalGroup")]
    public string BiologicalGroup { get; internal set; } = biologicalGroup;
}