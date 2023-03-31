using System;
using System.Collections.Generic;

namespace AdministratorDesktop.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Post { get; set; }

    public int? Type { get; set; }

    public string? SecretWord { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Photo { get; set; }

    public sbyte Verificated { get; set; }

    public virtual UserPost PostNavigation { get; set; } = null!;

    public virtual UserType? TypeNavigation { get; set; }

    public User()
    {
    }

    public User(int id, string fullName, string gender, int post, int? type, string? secretWord, string? login, string? password, string? photo, sbyte verificated, UserPost postNavigation, UserType? typeNavigation)
    {
        Id = id;
        FullName = fullName;
        Gender = gender;
        Post = post;
        Type = type;
        SecretWord = secretWord;
        Login = login;
        Password = password;
        Photo = photo;
        Verificated = verificated;
        PostNavigation = postNavigation;
        TypeNavigation = typeNavigation;
    }
}
