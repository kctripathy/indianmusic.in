﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Domain.ViewModels
{
    public class UserWithRolesViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }

    public class EditUserViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }

        public List<string> AllRoles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }

}
