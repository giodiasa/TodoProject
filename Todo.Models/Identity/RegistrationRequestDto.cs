﻿namespace Todo.Models.Identity
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
