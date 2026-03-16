namespace WatchStore.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }      // внешний ключ на пользователя
        public int ProductId { get; set; }       // внешний ключ на товар

        // Навигационные свойства
        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
    }
}