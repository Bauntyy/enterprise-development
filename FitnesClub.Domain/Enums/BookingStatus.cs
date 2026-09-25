namespace FitnesClub.Domain.Enums;

/// <summary>
/// Статус бронирования занятия
/// </summary>
public enum BookingStatus
{
    /// <summary>
    /// Ожидает подтверждения
    /// </summary>
    Pending = 1,

    /// <summary>
    /// Бронирование подтверждено
    /// </summary>
    Confirmed = 2,

    /// <summary>
    /// Клиент посетил занятие
    /// </summary>
    Attended = 3,

    /// <summary>
    /// Бронирование отменено
    /// </summary>
    Canceled = 4
}