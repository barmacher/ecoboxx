namespace Ecobox.Domain.Enums
{
    public enum ApplicationStatus
    {
        // Новая
        New = 0,
        // Выполняется бригадой
        Running = 1,
        // Завершено бригадой
        CompletedForBrigade = 2,
        // Завершено клиентом
        CompletedForClient = 3
    }
}
