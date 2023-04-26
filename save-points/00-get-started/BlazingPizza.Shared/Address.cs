namespace BlazingPizza;

public class Address
{
    public Address()
    {
        Name = "Asereware";
        Line1 = "Km 32 Carretera Malinalco Chalma";
        City = "Malinalco";
        Region = "EDOMEX, México";
        PostalCode = "52464";
    }
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    public string Line1 { get; set; }

    [MaxLength(100)]
    public string Line2 { get; set; }

    [Required, MaxLength(50)]
    public string City { get; set; }

    [Required(ErrorMessage = "How do you expect to receive the pizza if we don't even know what city you're in?"), MaxLength(20)]
    public string Region { get; set; }

    [Required, MaxLength(20)]
    public string PostalCode { get; set; }
}
