using System.ComponentModel.DataAnnotations;

namespace WatchStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Бренд")]
        public string Brand { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Изображение")]
        public string ImageUrl { get; set; } // путь к файлу изображения
    }
}