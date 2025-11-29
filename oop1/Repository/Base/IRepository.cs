using System.Collections.Generic;

namespace labaoop3.Repository.Base
{
    // Базовий інтерфейс репозиторію для CRUD-операцій
    public interface IRepository<T>
    {
        // Отримати всі записи
        IEnumerable<T> GetAll();

        // Отримати запис за його ідентифікатором
        T? GetById(int id);

        // Додати новий запис
        T Add(T entity);

        // Оновити існуючий запис
        void Update(T entity);

        // Видалити запис за ідентифікатором
        void Delete(int id);
    }
}
