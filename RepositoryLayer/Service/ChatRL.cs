using CommonLayer.Model;
using CommonLayer.Response;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class ChatRL : IChatRL
    {
        private readonly IConfiguration configuration;
        public ChatRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly string ConnectionString = "server=(LocalDb)\\LocalDB;Database=ChatAppDB;Trusted_Connection=true; MultipleActiveResultSets = true";

        public async Task<AddMessageResponseModel> AddMessage(AddMessageModel addMessageModel, int senderId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("AddMessage", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (senderId != addMessageModel.ReceiverId)
                {
                    sqlCommand.Parameters.AddWithValue("Message", addMessageModel.Message);
                    sqlCommand.Parameters.AddWithValue("SenderId", senderId);
                    sqlCommand.Parameters.AddWithValue("ReceiverId", addMessageModel.ReceiverId);
                    sqlConnection.Open();
                    var response = await sqlCommand.ExecuteNonQueryAsync();
                    if (response > 0)
                    {
                        var showResponse = new AddMessageResponseModel()
                        {

                            Message = addMessageModel.Message,
                            SenderId = senderId,
                            ReceiverId = addMessageModel.ReceiverId
                        };
                        return showResponse;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception ();
                }
               
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<IList<GetAllMessageResModel>> GetAllMessages(int senderId, int receiverId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlCommand = new SqlCommand("GetAllMessages", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("SenderId", senderId);
                sqlCommand.Parameters.AddWithValue("ReceiverId", receiverId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                IList<GetAllMessageResModel> messageList = new List<GetAllMessageResModel>();
                var model = new GetAllMessageResModel();
                while (sqlDataReader.Read())
                {
                    model = new GetAllMessageResModel();
                    model.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    model.Message = sqlDataReader["Message"].ToString();
                    model.ReceiverId = Convert.ToInt32(sqlDataReader["ReceiverId"]);
                    model.SenderId = Convert.ToInt32(sqlDataReader["SenderId"]);
                    messageList.Add(model);
                }
                sqlConnection.Close();
                return messageList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
