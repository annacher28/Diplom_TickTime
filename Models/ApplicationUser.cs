using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WatchStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
    }
}