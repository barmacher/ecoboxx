namespace Ecobox.Domain.Enums
{
    public enum ApplicationStatus
    {
        // Новая
        New = 0,
        // Выполняется бригадой
        Running = 1,
        // Завершено бригадой
        Completed = 2,
        // Завершено клиентом
        ComoletedForClient = 3
    }
}
