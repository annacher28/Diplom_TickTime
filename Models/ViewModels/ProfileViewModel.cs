using System.Collections.Generic;
using WatchStore.Models;

namespace WatchStore.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsAdmin { get; set; }
    }
}