namespace LoggerEx
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Tell us what do you want to call 1.Sql Server 2.Oracle Server 3. MySql Server");
                int choice = Convert.ToInt32(Console.ReadLine());

                DBFactory factory = new DBFactory();
                Database db = factory.GetDatabse(choice);

                Console.WriteLine("Tell us what do you want to call:");
                Console.WriteLine("1. Insert 2. Update 3. Delete");
                int opChoice = Convert.ToInt32(Console.ReadLine());
                switch (opChoice)
                {
                    case 1:
                        db.Insert();
                        break;
                    case 2:
                        db.Update();
                        break;
                    case 3:
                        db.Delete();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                Console.WriteLine("Do you want to continue? y/n");
                string ynChoice = Console.ReadLine();

                if (ynChoice == "n")
                {
                    break;
                }
            }
            Console.ReadLine();
        }

    }

    public abstract class Database
    {
        protected Logger logger = null;
        public Database()
        {
            logger = Logger.GetLogger();
        }
        protected abstract void DoInsert();
        protected abstract void DoUpdate();
        protected abstract void DoDelete();
        protected abstract string GetDataBaseServerName();

        public void Insert()
        {
            DoInsert();
            logger.Log("Insert happened into " + GetDataBaseServerName());
        }
        public void Update()
        {
            DoUpdate();
            logger.Log("Update happened into " + GetDataBaseServerName());
        }

        public void Delete()
        {
            DoDelete();
            logger.Log("Delete happened into " + GetDataBaseServerName());
        }
    }

    //Factory Class which produces Objects 
    public class DBFactory
    {
        //Factory Method 
        public Database GetDatabse(int choice)
        {
            if (choice == 1)
            {
                return new SQLServer();
            }
            else if (choice == 2)
            {
                return new OracleServer();
            }
            else if (choice == 3)
            {
                return new MySqlServer();
            }
            else
            {
                return null;
            }
        }
    }
    public class SQLServer : Database
    {
        //Logger logger = null;
        //public SQLServer()
        //{
        //    logger = Logger.GetLogger();
        //}

        protected override string GetDataBaseServerName()
        {
            return "Sql Server";
        }
        protected override void DoInsert()
        {
            //100 code
            Console.WriteLine("Data Inserted into SQL Server");

        }
        protected override void DoUpdate()
        {
            //100 code
            Console.WriteLine("Data Updated into SQL Server");

        }
        protected override void DoDelete()
        {
            //100 code
            Console.WriteLine("Data Deleted from SQL Server");

        }
    }
    public class MySqlServer : Database
    {
        //Logger logger = null;
        //public MySqlServer()
        //{
        //    logger = Logger.GetLogger();
        //}

        protected override string GetDataBaseServerName()
        {
            return "MySql Server";
        }
        protected override void DoDelete()
        {
            Console.WriteLine("Data Deleted from MySql Server");
        }

        protected override void DoInsert()
        {
            Console.WriteLine("Data Inserted into MySql Server");
        }

        protected override void DoUpdate()
        {
            Console.WriteLine("Data Updated into MySql Server");
        }
    }
    public class OracleServer : Database
    {
        //Logger logger = null;
        //public OracleServer()
        //{
        //   logger = Logger.GetLogger();
        //}
        protected override string GetDataBaseServerName()
        {
            return "Oracle Server";
        }
        protected override void DoInsert()
        {
            //100code
            Console.WriteLine("Data Inserted into Oracle Server");

        }
        protected override void DoUpdate()
        {
            //100code
            Console.WriteLine("Data Updated into Oracle Server");
        }
        protected override void DoDelete()
        {
            //100code
            Console.WriteLine("Data Deleted from Oracle Server");
        }
    }

    public class Logger
    {
        private static Logger logger = new Logger();
        // private static Logger logger1 =new Logger();
        private Logger()
        {
            // logger class realted initialization you can do it here...
            Console.WriteLine("Logger Object created for the First Time ...");
        }

        public static Logger GetLogger()
        {
            return logger;
        }
        public void Log(string message)
        {
            //Console.WriteLine("Logged " + message + " at " + DateTime.Now.ToString());

            FileStream stream = new FileStream(@"D://log.txt",FileMode.Append);
            using(StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine("Logged " + message + " at " + DateTime.Now.ToString());
                Console.WriteLine("Logged...");
            }
        }
    }
}
