namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int BusinessEntityID { get; set; }

        public int PersonId { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberType { get; set; }

        public PersonDto Person { get; set; }
    }
}
