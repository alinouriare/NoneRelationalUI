namespace Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        //public Person  Person { get; set; }
        public byte[] RowVersion { get; set; }

        public string AccNumber { get; set; }
    }
}
