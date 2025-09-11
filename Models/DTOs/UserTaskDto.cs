using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Razor_Pages_Todo.Models.DTOs
{
    public class UserTaskDto
    {
        [Required(ErrorMessage = "У задачи должно быть название")]
        [MinLength(1, ErrorMessage = "Минимальная длина названия задачи - {1} символов")]
        [MaxLength(128, ErrorMessage = "Максимальная длина названия задачи - {1} символов")]
        [DisplayName("Название задачи")]
        [DataType(DataType.Text)]
        public string? Title { get; set; }

        [MaxLength(512, ErrorMessage = "Максимальная длина описания задачи - {1} символов")]
        [DisplayName("Описание задачи")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
