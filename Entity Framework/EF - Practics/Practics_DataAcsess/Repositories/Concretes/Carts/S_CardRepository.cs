using Practics_DataAcsess.Repositories.Abstracts;
using Practics_DataAcsess.Repositories.Abstracts.Carts;
using Practics_Model.Entities.Concretes;
using Practics_Model.Entities.Concretes.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics_DataAcsess.Repositories.Concretes.Carts;

public class S_CardRepository<T> : BaseRepository<S_Card>, IS_CardRepository
{
    
}
