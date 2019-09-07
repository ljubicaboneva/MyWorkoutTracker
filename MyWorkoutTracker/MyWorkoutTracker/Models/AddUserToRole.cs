using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWorkoutTracker.Models
{
    public class AddToRoleModel
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string SelectedRole { get; set; }
        public List<String> roles { get; set; }

        public AddToRoleModel()
        {
            roles = new List<string>();
        }
    }
}