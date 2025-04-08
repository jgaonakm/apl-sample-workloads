public class Animal(int id, double? lat, double? lng, string phylum, string className, string order, string family, string genus, string? subnegnus, string specie,
    string country, string? state, string? city, string? area, string source, string biologicalGroup)
{

    public int Id => id;
    public double? Lat => lat;
    public double? Long => lng;
    public string Phylum => phylum;
    public string Class => className;
    public string Order => order;
    public string Family => family;
    public string Genus => genus;
    public string? Subgenus => subnegnus;
    public string Specie => specie;
    public string Country => country;
    public string? State => state;
    public string? City => city;
    public string? Area => area;
    public string Source => source;
    public string BiologicalGroup => biologicalGroup;
}