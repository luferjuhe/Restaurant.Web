using System;
namespace Restaurant.Web.ViewModels
{
	public class RoleViewModel
	{
        public int RoleId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int CreationUserId { get; set; }
    }
}

