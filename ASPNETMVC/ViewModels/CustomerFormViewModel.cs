using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNETMVC.Models;

namespace ASPNETMVC.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}