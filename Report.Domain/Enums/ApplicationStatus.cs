namespace Ecobox.Domain.Enums
{
    public enum ApplicationStatus
    {
        // Новая
        New = 0,
        // Ожидание обработки менеджером
        Processing = 1,
        // Выполняется бригадой
        Running = 2,
        // Заверщено
        Completed = 3
    }
}
