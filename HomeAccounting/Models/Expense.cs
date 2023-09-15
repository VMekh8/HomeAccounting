using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeAccounting.Models
{
    public class Expense : ExpenseDBInitializer
    {
        [Required(ErrorMessage = "Це поле обов'язкове для заповнення")]
        [Range(0, double.MaxValue, ErrorMessage = "Значення не може бути від'ємним")]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Це поле обов'язкове для заповнення")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Це поле обов'язкове для заповнення")]
        [Range(0, double.MaxValue, ErrorMessage = "Значення не може бути від'ємним")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Це поле обов'язкове для заповнення")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Це поле обов'язкове для заповнення")]
        public DateTime Date { get; set; }
    }
}