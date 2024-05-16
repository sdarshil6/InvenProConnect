namespace InvenProConnect.DTOs
{
    public class GetAllUsersDto
    {
        public long UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public string Role { get; set; } = null!;

        public long? Salary { get; set; }

        public DateOnly? JoinDate { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string Phone { get; set; } = null!;

        public string? HomeTown { get; set; }

        public string? CurrentCity { get; set; }

        public string? BloodGroup { get; set; }

        public string? PostalCodeHomeTown { get; set; }

        public string? PostalCodeCurrentCity { get; set; }
    }
}
