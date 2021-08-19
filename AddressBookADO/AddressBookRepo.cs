using System;
using System.Data.SqlClient;

namespace AddressBookADO
{
    public class AddressBookRepo
    {
        public static string connectionString = "Server=127.0.0.1,1433;Database=AddressBook;User=sa;Password=Password123@pra#";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddContacts(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    //var qury=values()
                    SqlCommand command = new SqlCommand("spAddAddressBook", this.connection);
                  
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatementType", "INSERT");
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", model.EmailId);

                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }


        public bool EditContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddAddressBook", this.connection);
                   
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatementType", "UPDATE");
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", model.EmailId);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool DeleteContact(AddressBookModel model)
        {
            try
            {
                SqlCommand command = new SqlCommand("spAddAddressBook", this.connection);
          
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StatementType", "DELETE");
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@City", model.City);
                command.Parameters.AddWithValue("@State", model.State);
                command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@EmailId", model.EmailId);

                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool DisplayByCityOrState(AddressBookModel model)
        {
            try
            {
                string query = @"Select * from AddressBook where City = 'Austin'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        model.FirstName = dr.GetString(1);
                        model.LastName = dr.GetString(2);
                        model.Address = dr.GetString(3);
                        model.City = dr.GetString(4);
                        model.State = dr.GetString(5);
                        model.ZipCode = dr.GetString(6);
                        model.PhoneNumber = dr.GetString(7);
                        model.EmailId = dr.GetString(8);

                        Console.WriteLine($"{model.FirstName} {model.LastName}, " +
                            $"{model.Address}, {model.City}, {model.State}" +
                            $", {model.ZipCode}, {model.PhoneNumber}, {model.EmailId}");

                        Console.WriteLine("\n");

                        dr.Close();
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No data found");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}




