using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorDesktop.Models
{
    public partial class User
    {
        public string Surname { get { return FullName.Split(' ')[0]; } }
        public string Name { get { return FullName.Split(' ')[1]; } }
        public string Patronomic { get { return FullName.Split(' ')[2]; } }
        public string StringPost { get { return PostNavigation == null ? "-" : PostNavigation.Name; } }
        public bool IsVerificated { get { return Verificated == 1 ? true : false; } }
    }
}
