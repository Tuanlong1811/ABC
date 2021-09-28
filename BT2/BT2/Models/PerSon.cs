using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BT2.Models
{
    public class PerSon
    {
        [Key]
        [Required(ErrorMessage ="Hãy Nhập ID")]
        public String PerSonID { get; set; }

        [Required(ErrorMessage = "Hãy Nhập Tên")]
        public String PsName { get; set; }

        [Required(ErrorMessage = "Hãy Nhập Địa Chỉ")]
        public String Address { get; set; }
    }
}