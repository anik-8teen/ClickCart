using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepoA
{
   public class Repo
    {
        internal ClickCart db;
        internal Repo()
        {
            db = new ClickCart();
        }
    }
}
