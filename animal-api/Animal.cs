using System.Runtime.Serialization;

[DataContract(Name = "animal")]
public class Animal(int id, double? lat, double? lng, string phylum, string className, string order, string family, string genus, string? subgenus, string specie,
  string country, string? state, string? city, string? area, string source, string biologicalGroup)
{
    [DataMember(Name = "id")]
    public int Id { get; set; } = id;
    [DataMember(Name = "lat")]
    public double? Lat { get; set; } = lat;

    [DataMember(Name = "lng")]
    public double? Lng { get; set; } = lng;
    [DataMember(Name = "phylum")]
    public string Phylum { get; set; } = phylum;
    [DataMember(Name = "className")]
    public string ClassName { get; set; } = className;
    [DataMember(Name = "order")]
    public string Order { get; set; } = order;
    [DataMember(Name = "family")]
    public string Family { get; set; } = family;

    [DataMember(Name = "genus")]
    public string Genus { get; set; } = genus;
    [DataMember(Name = "subgenus")]
    public string? Subgenus { get; set; } = subgenus;
    [DataMember(Name = "specie")]
    public string Specie { get; set; } = specie;
    [DataMember(Name = "country")]
    public string Country { get; set; } = country;
    [DataMember(Name = "state")]
    public string? State { get; set; } = state;
    [DataMember(Name = "city")]
    public string? City { get; set; } = city;
    [DataMember(Name = "area")]
    public string? Area { get; set; } = area;
    [DataMember(Name = "source")]
    public string Source { get; set; } = source;
    [DataMember(Name = "biologicalGroup")]
    public string BiologicalGroup { get; set; } = biologicalGroup;
}