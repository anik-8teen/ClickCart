using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    
        public interface InRepo<TYPE, ID, RET>
        {
            List<TYPE> Get();
            TYPE Get(ID id);
            TYPE Insert(TYPE obj);
            TYPE Update(TYPE obj);
            bool Delete(ID id);

        }
    }
