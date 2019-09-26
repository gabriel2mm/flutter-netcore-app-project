using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class ModelRepository : RepositoryBase<Model>, IModelRepository
    {
    }
}
