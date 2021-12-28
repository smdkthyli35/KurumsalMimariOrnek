using Core.Data;
using Data.Abstract;
using Entities.Concrete;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IEntityRepository<Person> entityRepository) : base(unitOfWork, entityRepository)
        {
        }
    }
}
