﻿namespace CollectionsAndLinq.BL.Entities;

public class User
{
    public int Id { get; set; }
    public int? TeamId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime BirthDay { get; set; }
}
