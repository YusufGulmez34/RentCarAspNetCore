using Core.DataAccess.EntityFramework.Abstract;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BussinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
