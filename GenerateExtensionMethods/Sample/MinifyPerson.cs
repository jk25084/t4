using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaLing.Models.Account;
using VivaLing.Models.BaseData;
using VivaLing.Pattern.Attributes;

namespace VivaLing.Models.Account
{
    // ↑ this namespace must be consistent with the source type
    [DerivedFrom(typeof(Person))]
    public partial class MinifyPerson
    {
        public string Email { get; set; }

        public Enums.Roles MajorRole { get; set; }

        public MinifyAccount Account { get; set; }

        public List<MinifyPersonExtension> Extensions { get; set; }
    }

    [DerivedFrom(typeof(Account))]
    public partial class MinifyAccount
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [DerivedFrom(typeof(PersonExtension))]
    public class MinifyPersonExtension
    {
        public int Id { get; set; }
    }
}
