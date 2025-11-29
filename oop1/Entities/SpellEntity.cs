namespace labaoop3.Entities
{
    // Клас для зберігання інформації про закляття
    public class SpellEntity
    {
        // Унікальний ідентифікатор закляття
        public int Id { get; set; }

        // Назва закляття
        public string Name { get; set; } = string.Empty;

        // Шкода, яку завдає закляття
        public int Damage { get; set; }

        // Тип ефекту закляття (наприклад, Disarming, Stunning, Damage)
        public string Effect { get; set; } = string.Empty;
    }
}
