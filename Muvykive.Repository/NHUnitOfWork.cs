using System;
using Muvykive.Model;
using NHibernate;

namespace Muvykive.Repository
{
    public class NHUnitOfWork : IUnitOfWork
    {
        #region IUnitOfWork Members

        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        #endregion
    }
}