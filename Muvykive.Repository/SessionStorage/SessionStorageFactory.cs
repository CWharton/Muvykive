using System.Web;

namespace Muvykive.Repository.SessionStorage
{
    public static class SessionStorageFactory
    {
        public static ISessionStorageContainer NhSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (NhSessionStorageContainer == null)
            {
                if (HttpContext.Current != null)
                    NhSessionStorageContainer = new HttpSessionContainer();
            }

            return NhSessionStorageContainer;
        }
    }
}
