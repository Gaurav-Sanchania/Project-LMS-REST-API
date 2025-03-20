using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.User;
using WebApplication2.Models.StaticDepartmentType;
using WebApplication2.Models.StaticUserType;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("UserController")]
    public class UserController(IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _config = configuration;

        // GET: UserController
        [Route("UserController")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersController/GetAllUsers
        [HttpGet]
        [Route("GetAllUsers")]
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 1);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User();

                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Address = reader["Address"].ToString();
                    user.Phone = reader["Phone"].ToString();
                    user.Department = reader["Department"].ToString();
                    user.UserType = reader["UserType"].ToString();
                    //user.LeaveBalance = Convert.ToInt32(reader["LeaveBalance"]);
                    user.Password = reader["Password"].ToString();

                    users.Add(user);
                }
            }
            return users;
        }

        // GET: UsersController/GetUsersOnLeave/{InputDate}
        [HttpGet]
        [Route("GetUsersOnLeave/{InputDate}")]
        public List<ListUsersOnLeave> GetUsersOnLeave(string InputDate)
        {
            List<ListUsersOnLeave> users = new List<ListUsersOnLeave>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 6);
                cmd.Parameters.AddWithValue("@InputDate", InputDate);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var listUserOnLeave = new ListUsersOnLeave();

                    listUserOnLeave.Id = Convert.ToInt32(reader["Id"]);
                    listUserOnLeave.Name = reader["Name"].ToString();
                    listUserOnLeave.Email = reader["Email"].ToString();
                    listUserOnLeave.Department = reader["DepartmentName"].ToString();
                    listUserOnLeave.UserType = reader["UserType"].ToString();
                    //listUserOnLeave.LeaveBalance = Convert.ToInt32(reader["LeaveBalance"]);

                    users.Add(listUserOnLeave);
                }
            }
            return users;
        }

        // GET: UsersController/GetUsersPresent/{InputDate}
        [HttpGet]
        [Route("GetUsersPresent/{InputDate}")]
        public List<ListUsersOnLeave> GetUsersPresent(string InputDate)
        {
            List<ListUsersOnLeave> users = new List<ListUsersOnLeave>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 7);
                cmd.Parameters.AddWithValue("@InputDate", InputDate);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var listUserOnLeave = new ListUsersOnLeave();

                    listUserOnLeave.Id = Convert.ToInt32(reader["Id"]);
                    listUserOnLeave.Name = reader["Name"].ToString();
                    listUserOnLeave.Email = reader["Email"].ToString();
                    listUserOnLeave.Department = reader["DepartmentName"].ToString();
                    listUserOnLeave.UserType = reader["UserType"].ToString();
                    //listUserOnLeave.LeaveBalance = Convert.ToInt32(reader["LeaveBalance"]);

                    users.Add(listUserOnLeave);
                }
            }
            return users;
        }

        // GET: UsersController/GetUserById/{id}
        [HttpGet]
        [Route("GetUserById/{id}")]
        public User GetUserById(int id)
        {
            var user = new User();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 2);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Address = reader["Address"].ToString();
                    user.Phone = reader["Phone"].ToString();
                    user.Department = reader["Department"].ToString();
                    user.UserType = reader["UserType"].ToString();
                    //user.LeaveBalance = Convert.ToInt32(reader["LeaveBalance"]);
                    user.Password = reader["Password"].ToString();
                }
            }
            return user;
        }

        // GET: UserController/PieChartCountOnLeave/{inputDate}
        [HttpGet]
        [Route("PieChartCountOnLeave/{inputDate}")]
        public int PieChartCountOnLeave(string inputDate) 
        { 
            int count = 0;
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@case", 8);
                cmd.Parameters.AddWithValue("@InputDate", inputDate);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["RecordCount"]);
                }
            }
            return count;
        }

        // GET: UserController/PieChartCountPresent/{inputDate}
        [HttpGet]
        [Route("PieChartCountPresent/{inputDate}")]
        public int PieChartCountPresent(string inputDate)
        {
            int count = 0;
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@case", 9);
                cmd.Parameters.AddWithValue("@InputDate", inputDate);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["RecordCount"]);
                }
            }
            return count;
        }

        // GET: UserController/GetLoginCredential
        [HttpGet]
        [Route("GetLoginCredential")]
        public List<LoginCreadentialUser> GetLoginCredential()
        {
            List<LoginCreadentialUser> users = new List<LoginCreadentialUser>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 10);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new LoginCreadentialUser();

                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Username = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.UserType = reader["UserType"].ToString();
                    user.Password = reader["Password"].ToString();

                    users.Add(user);
                }
            }
            return users;
        }

        // GET: UserController/GetUserLeaveBalance/{id}
        [HttpGet]
        [Route("GetUserLeaveBalance/{id}")]
        public List<UserLeaveBalanceModel> GetUserLeaveBalanceModel(int id)
        {
            List<UserLeaveBalanceModel> users = new List<UserLeaveBalanceModel>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 11);
                cmd.Parameters.AddWithValue("@InputUserId", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserLeaveBalanceModel user = new UserLeaveBalanceModel();

                    user.UserName = reader["Name"].ToString();
                    user.LeaveBalance = Convert.ToInt32(reader["LeaveBalance"]);
                    user.LeaveTypeId = Convert.ToInt32(reader["LeaveTypeId"]);
                    user.LeaveType = reader["LeaveType"].ToString();

                    users.Add(user);
                }
            }
            return users;
        }

        // GET: UserController/GetDepartmentTypes
        [HttpGet]
        [Route("GetDepartmentTypes")]
        public List<DepartmentModel> GetDepartmentTypes()
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 12);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new DepartmentModel();

                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();

                    departmentModels.Add(user);
                }
            }
            return departmentModels;
        }

        // GET: UserController/GetUserTypes
        [HttpGet]
        [Route("GetUserTypes")]
        public List<UserTypeModel> GetUsersTypes()
        {
            List<UserTypeModel> userModel = new List<UserTypeModel>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 13);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new UserTypeModel();

                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();

                    userModel.Add(user);
                }
            }
            return userModel;
        }

        // <------------------------------------------------------------------------------------------------------------------------->

        // Post: UserController/AddUser
        [HttpPost]
        [Route("AddUser")]
        public void AddUser(AddUserModel user)
        {
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 3);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@DepartmentType", user.Department);
                cmd.Parameters.AddWithValue("@UserType", user.UserType);
                //cmd.Parameters.AddWithValue("@LeaveBalance", user.LeaveBalance);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cmd.ExecuteNonQuery();
            }
        }

        // Post: UserController/RemoveUser/{id}
        [HttpPost]
        [Route("RemoveUser/{id}")]
        public void RemoveUser(int id)
        {
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 4);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        // Post: UserController/UpdateUser
        [HttpPost]
        [Route("UpdateUser")]
        public void UpdateUser([FromBody] EditUserModel user)
        {
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Users]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 5);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@DepartmentType", user.Department);
                cmd.Parameters.AddWithValue("@UserType", user.UserType);
                //cmd.Parameters.AddWithValue("@LeaveBalance", user.LeaveBalance);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
