namespace FitnesClub.Domain.Entities;

/// <summary>
/// Клиент фитнес-клуба
/// </summary>
public class Member : Person
{
    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    /// <example>+79991112233</example>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Дата начала абонемента
    /// </summary>
    public required DateTime MembershipStartDate { get; set; }

    /// <summary>
    /// Дата окончания абонемента
    /// </summary>
    public required DateTime MembershipEndDate { get; set; }

    /// <summary>
    /// Электронная почта клиента
    /// </summary>
    /// <example>ivan@test.com</example>
    public string? Email { get; set; }

    /// <summary>
    /// Список записей клиента на занятия
    /// </summary>
    public List<Booking> Bookings { get; set; } = [];
}