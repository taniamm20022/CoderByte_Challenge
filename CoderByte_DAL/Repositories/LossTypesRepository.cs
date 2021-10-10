using CoderByte_DAL.Models;
using CoderByte_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderByte_DAL.Repositories
{
    public class LossTypesRepository : GenericRepository<InterviewContext, LossType>, ILossTypesRepository
    {
        public LossTypesRepository(
            InterviewContext ctx)
            : base(ctx)
        {
        }
    }
}

