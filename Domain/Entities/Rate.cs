using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //model of rate of content
    public class Rate
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        //value of rate
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите значение!")]
        [Range(1, 10, ErrorMessage = "Вне диапазона допустимых значений")]
        [Display(Name = "Оценка")]
        [UIHint("Decimal")]
        public int Value { get; set; }
        //description of rate
        [Required]
        [Display(Name = "Отзыв")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //navigation property
        //relationship between Content and Rate: many-to-one
        public virtual Content Content { get; set; }
        //foreign key
        [Required]
        [ForeignKey("Content")]
        public int ContentID { get; set; }
    }
}
