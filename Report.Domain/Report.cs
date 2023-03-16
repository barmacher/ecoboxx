namespace Reports.Domain
{
    public class Report
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? EditDate { get; set;}

        // ertgyhgffdrtgt

    }
}