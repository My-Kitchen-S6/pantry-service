namespace pantry_service.DTOs
{
    public class ReadUser
    {
        public int Id { get; set; }
        
        public string Auth0Id { get; set; }

        public string UserName { get; set; }

    }
}