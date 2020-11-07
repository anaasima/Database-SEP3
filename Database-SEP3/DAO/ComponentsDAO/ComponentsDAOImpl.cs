namespace Database_SEP3.DAO.ComponentsDAO
{
    public class ComponentsDAOImpl : ComponentsDAO
    {
        private static readonly object padlock = new object();
        private static ComponentsDAOImpl _instance = null;

        public static ComponentsDAOImpl GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new ComponentsDAOImpl();
                    }

                    return _instance;
                }
            }
        }
    }
}