using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication2.Models.Leave;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("LeaveController")]
    public class LeaveController(IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _config = configuration;

        // GET: LeaveController
        [Route("LeaveController")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: LeaveController/GetAllLeaveRequest
        [HttpGet]
        [Route("GetAllLeaveRequest")]
        public List<Leave> GetAllLeaveRequest()
        {
            List<Leave> leaves = new List<Leave>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Leave leave = new Leave();
                    leave.Id = Convert.ToInt32(reader["Id"]);
                    leave.StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["StartDate"]));
                    leave.EndDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EndDate"]));
                    leave.TotalDays = ((leave.EndDate.ToDateTime(TimeOnly.MinValue) - leave.StartDate.ToDateTime(TimeOnly.MinValue)).Days) + 1;
                    leave.Reason = reader["Reason"].ToString();
                    leave.User_Name = reader["User"].ToString();
                    leave.Admin_Name = reader["Admin"].ToString();
                    leave.User_Department = reader["Department"].ToString();
                    leave.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    leave.UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]);
                    leave.CreatedBy = reader["CreatedBy"].ToString();
                    leave.UpdatedBy = reader["UpdatedBy"].ToString();
                    leave.Status = reader["Status"].ToString();
                    leave.Leave_Type = reader["LeaveType"].ToString();
                    leave.CC = reader["CC"].ToString();
                    leave.BCC = reader["BCC"].ToString();

                    leaves.Add(leave);
                }
            }
            return leaves;
        }

        // GET: LeaveController/GetLeaveById/id
        [HttpGet]
        [Route("GetLeaveById/{id}")]
        public Leave GetLeaveById(int id)
        {
            Leave leave = new Leave();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 2);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    leave.Id = Convert.ToInt32(reader["Id"]);
                    leave.StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["StartDate"]));
                    leave.EndDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EndDate"]));
                    leave.TotalDays = ((leave.EndDate.ToDateTime(TimeOnly.MinValue) - leave.StartDate.ToDateTime(TimeOnly.MinValue)).Days) + 1;
                    leave.Reason = reader["Reason"].ToString();
                    leave.User_Name = reader["User"].ToString();
                    leave.Admin_Name = reader["Admin"].ToString();
                    leave.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    leave.UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]);
                    leave.CreatedBy = reader["CreatedBy"].ToString();
                    leave.UpdatedBy = reader["UpdatedBy"].ToString();
                    leave.Status = reader["Status"].ToString();
                    leave.Leave_Type = reader["LeaveType"].ToString();
                    leave.BCC = reader["BCC"].ToString();
                    leave.CC = reader["CC"].ToString();
                }
            }
            return leave;
        }

        // GET: LeaveController/GetLeaveRequestsForUser/{id}
        [HttpGet]
        [Route("GetLeaveRequestsForUser/{id}")]
        public List<GetLeavesModel> GetLeaveRequestsForUser(int id)
        {
            List<GetLeavesModel> leaves = new List<GetLeavesModel>();
            string cs = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(cs);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 9);
                cmd.Parameters.AddWithValue("@InputUserId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                { 
                    var leave = new GetLeavesModel();

                    leave.Id = Convert.ToInt32(reader["Id"]);
                    leave.StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["StartDate"]));
                    leave.EndDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EndDate"]));
                    leave.Status = reader["LeaveStatus"].ToString();
                    leave.LeaveType = reader["LeaveType"].ToString();
                    //leave.Reason = reader["Reason"].ToString();

                    leaves.Add(leave);
                }
            }
            return leaves;
        }

        // GET: LeaveController/GetLeaveTypes
        [HttpGet]
        [Route("GetLeaveTypes")]
        public List<LeaveTypesModel> GetLeaveTypes()
        {
            List<LeaveTypesModel> leaveTypes = new List<LeaveTypesModel>();
            string cs = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(cs);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 10);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var leave = new LeaveTypesModel();

                    leave.Id = Convert.ToInt32(reader["Id"]);
                    leave.Name = reader["LeaveType"].ToString();
                    leave.MaxLeave = Convert.ToInt32(reader["MaxLeave"]);

                    leaveTypes.Add(leave);
                }
            }
            return leaveTypes;
        }

        // GET: LeaveController/GetAllHolidays
        [HttpGet]
        [Route("GetAllHolidays")]
        public List<HolidaysModel> GetAllHolidays()
        {
            List<HolidaysModel> holidays = new List<HolidaysModel>();
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 11);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HolidaysModel holidaysModel = new HolidaysModel();
                    holidaysModel.Id = Convert.ToInt32(reader["Id"]);
                    holidaysModel.Event = reader["Events"].ToString();
                    holidaysModel.DateOfEvent = DateOnly.FromDateTime(Convert.ToDateTime(reader["DateOfEvent"]));

                    holidays.Add(holidaysModel);
                }
            }
            return holidays;
        }

        //--------------------------------------------------------------------------------------------------

        // POST: LeaveController/ApproveLeave/{id}
        [HttpPost]
        [Route("ApproveLeave/{id}")]
        public void ApproveLeave(int id)
        {
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 7);
                cmd.Parameters.AddWithValue("@InputLeaveId", id);

                cmd.ExecuteNonQuery();
            }
        }

        // POST: LeaveController/RejectLeave/{id}
        [HttpPost]
        [Route("RejectLeave/{id}")]
        public void RejectLeave(int id)
        {
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 8);
                cmd.Parameters.AddWithValue("@InputLeaveId", id);

                cmd.ExecuteNonQuery();
            }
        }

        // POST: LeaveController/AddLeaveRequest
        [HttpPost]
        [Route("AddLeaveRequest")]
        public void AddLeaveRequest(AddLeaveModel leave)
        {
            string CS = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(CS);
            using(SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 3);
                cmd.Parameters.AddWithValue("@InputAdminEmail", leave.AdminEmail);
                cmd.Parameters.AddWithValue("@StartDate", leave.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", leave.EndDate);
                cmd.Parameters.AddWithValue("@UserId", leave.UserId);
                cmd.Parameters.AddWithValue("@Reason", leave.Reason);
                cmd.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
                cmd.Parameters.AddWithValue("@CC", leave.CC);
                cmd.Parameters.AddWithValue("@BCC", leave.BCC);

                cmd.ExecuteNonQuery();
            }
        }

        // POST: LeaveController/DeleteLeaveRequest/{id}
        [HttpPost]
        [Route("DeleteLeaveRequest/{id}")]
        public void DeleteLeaveRequest(int id)
        {
            string cs = _config.GetConnectionString("LeaveZ");
            SqlConnection con = new SqlConnection(cs);
            using (SqlCommand cmd = new SqlCommand("[dbo].[CRUD_Leaves]", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@case", 4);
                cmd.Parameters.AddWithValue("Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
