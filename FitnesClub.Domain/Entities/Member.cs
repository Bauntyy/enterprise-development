using FitnesClub.Domain.Enums;

namespace FitnesClub.Domain.Entities;

/// <summary>
/// Клиент фитнес-клуба
/// </summary>
public class Member
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Имя клиента
    /// </summary>
    /// <example>Иван</example>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    /// <example>Иванов</example>
    public required string LastName { get; set; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    /// <example>+79991112233</example>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Дата рождения клиента
    /// </summary>
    public required DateTime BirthDate { get; set; }

    /// <summary>
    /// Дата вступления в фитнес-клуб
    /// </summary>
    public required DateTime JoinDate { get; set; }

    /// <summary>
    /// Адрес электронной почты клиента
    /// </summary>
    /// <example>ivan@test.com</example>
    public string? Email { get; set; }

    /// <summary>
    /// Признак активности клиента
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Тип абонемента клиента
    /// </summary>
    public MembershipType MembershipType { get; set; } = MembershipType.Standard;

    /// <summary>
    /// Список бронирований клиента
    /// </summary>
    public List<Booking> Bookings { get; set; } = [];
}