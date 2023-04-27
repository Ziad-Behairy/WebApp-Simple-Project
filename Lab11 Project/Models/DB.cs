using System.Data.SqlClient;
using System.Data;
namespace Lab11_Project.Models
{
    public class DB
    {
        SqlConnection conn;
        private List<User> AllUsers { get; set; }

        public DB()
        {
            string Constr = "Data Source=ELZOZ;Initial Catalog=LAB11;Integrated Security=True";
            conn=new SqlConnection(Constr);
            AllUsers = GetUsers();
        }

        public int GetUserType(string username)
        {
            string Q = "SELECT UserType FROM USERS WHERE UserName= @username";

            return (int)ExecuteScalarQuery(Q);

		}
		public int Gettotal()
		{
			string Q = "SELECT COUNT(*) FROM USERS ";

			return (int)ExecuteScalarQuery(Q);

		}

      

        public List <User> GetUsers()
        {
           
            DataTable dataTable = (DataTable)ReadTableAction();
            AllUsers= new List<User>();
            foreach (DataRow dr in dataTable.Rows)
            {
                AllUsers.Add(new User
                {
                    Id = (int)dr["ID"],
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    UserName = dr["Username"].ToString(),
                    Password = dr["Password"].ToString(),
                    UserType = (int)dr["user_type"]
                });
            }

            return AllUsers;    
        }

		public object ReadTableAction(){ // fun that take table name and read all elements in it 
            string Q = " SELECT * FROM USERS";
            return ReadTbExcution(Q);
        }

        public bool CheckUserCredentials(string email, string password)
        {
            var user = AllUsers.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null;
        }
        public User GetUserByEmail(string email)
        {
            List<User> users = GetUsers(); // assuming you have a method to get all users

            if (users != null)
            {
                var user = users.FirstOrDefault(u => u.Email == email);
                return user;
            }

            return null;
        }
        private string ExecuteNonQuery(string query)
		{
			try
			{
					conn.Open();
				SqlCommand cmd = new SqlCommand(query, conn);
				// execute the command and retrieve the number of rows affected
				int rowsAffected = cmd.ExecuteNonQuery();

				conn.Close(); // close the connection after executing the command

				return $"{rowsAffected} rows affected."; // return a string message indicating the number of rows affected
			}
			catch (SqlException ex)
			{
				conn.Close(); // close the connection if an exception occurs
				return ex.Message; // return the exception message
			}
		}

		private object ExecuteScalarQuery(string query)
{
    try
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);

        object result = cmd.ExecuteScalar();

        conn.Close();

        return result;
    }
    catch (SqlException ex)
    {
        conn.Close();
        return ex;
    }
}

        private object  ReadTbExcution (string Q) { // excute any read table  query  "RETRUN TABLE"
             DataTable dt = new DataTable();    
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Q, conn); // remember--> command take the query and the connection 
                dt.Load(cmd.ExecuteReader()); //take the table data from my db and store it in this table 
                conn.Close(); // i should close the connection after fininshin
                return dt; // this fun retrun table containg data that come from the excution of the query i wrote it 
            }
            catch (SqlException Ex)
            {
				conn.Close();
				return Ex;
            }
        }

    }
}
