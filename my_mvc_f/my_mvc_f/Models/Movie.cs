using System;
using System.ComponentModel.DataAnnotations;
//使用数据库链接库
using System.Data.Entity;

namespace my_mvc_f.Models
{
    public class Movie
    {
        //对title属性的长度进行限制 最大长度为60 最小长度是3
        
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        //对日期添加属性
        [Display(Name ="Release Name")] //改变显示的名字
        [DataType(DataType.Date)]//显示类型为date
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }
        #region
        /// <summary>
        /// 电影类型
        /// </summary>
        /// 正则表达式
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        //设置必填
        [Required]
        [StringLength(30)]
        public string Gerne { get; set; }
        #endregion
        [Range(1,100)]
        //设置数据类型
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
    //引用Entity Framework链接数据库
    public class MovieDBContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
    }
}