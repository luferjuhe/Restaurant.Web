﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.ViewModels
{
	public class LogInViewModel
	{
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}

