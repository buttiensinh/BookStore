﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class TheLoai
    {
        public int ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Tên thể loại không được bỏ trống!")]
		[DisplayName("Tên loại")]
		public string TenTheLoai { get; set; }

        public ICollection<Sach>? Sach { get; set; }

    }
}
