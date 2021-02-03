using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;//for ADO.NET classes connection and command
using PBAEntitiesLayerLib;
using PBAExceptionLib;

namespace PBADataAccessLayerLib
{
    public class PBADataAccessLayer : IPBADataAccess
    {
        SqlCommand cmd;
        SqlConnection con;
        public PBADataAccessLayer()
        {
            //configure connection object
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=HCL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        /// <summary>
        /// Displaying the records of Contact Category
        /// </summary>
        public List<ContactCategory> GetAllcategoryNames()
        {
            List<ContactCategory> lstcat = new List<ContactCategory>();
            try
            {
                //configure command for SELECT statement
                cmd = new SqlCommand();
                cmd.CommandText = "select * from ContactCategory";
                //attach the connection with the command
                cmd.Connection = con;

                //open the connection 
                con.Open();

                //execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                //read the records from data reader and add them to the collection 
                while (sdr.Read())
                {
                    ContactCategory c = new ContactCategory
                    {
                        CategoryId = (int)sdr[0],
                        CategoryName = sdr[1].ToString(),
                    };
                    lstcat.Add(c);
                }
                //close the data reader 
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new PBAException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException(ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
            //returning all the records using collection
            return lstcat;
        }
        /// <summary>
        /// Inserting records into the ContactCategory
        /// </summary>
        /// <param name="cat"></param>
        public void AddContactCategory(ContactCategory cat)
        {
            try
            {
                //configure command for INSERT statemnt
                cmd = new SqlCommand();
                cmd.CommandText = "insert into ContactCategory values(@catid,@catname)";
                //Attach the connection with the command
                cmd.Connection = con;
                cmd.Parameters.Clear();
                //supplying the values to the parameters of the command
                cmd.Parameters.AddWithValue("@catid", cat.CategoryId);
                cmd.Parameters.AddWithValue("@catname", cat.CategoryName);
                cmd.CommandType = CommandType.Text;
                //open the connection
                con.Open();
                //Execute the Command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PBAException("Could not insert data");
                }
            }
            catch (SqlException ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Inserting records into Contact
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(Contact contact)
        {
            try
            {
                //configure command for INSERT statement
                cmd = new SqlCommand();
                cmd.CommandText = "insert into Contact values(@conid,@catid,@fname,@lname,@gender,@dob,@phonenumber,@emailid,@city,@state,@country)";
                //Attach connection with the command
                cmd.Connection = con;
                cmd.Parameters.Clear();
                //supply values to the parameters of the command
                cmd.Parameters.AddWithValue("@conid", contact.ContactId);
                cmd.Parameters.AddWithValue("@catid", contact.CategoryId);
                cmd.Parameters.AddWithValue("@fname", contact.FirstName);
                cmd.Parameters.AddWithValue("@lname", contact.LastName);
                cmd.Parameters.AddWithValue("@gender", contact.Gender);
                cmd.Parameters.AddWithValue("@dob", contact.DateOfBirth);
                cmd.Parameters.AddWithValue("@phonenumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@emailid", contact.EmailId);
                cmd.Parameters.AddWithValue("@city", contact.City);
                cmd.Parameters.AddWithValue("@state", contact.State);
                cmd.Parameters.AddWithValue("@country", contact.Country);
                cmd.CommandType = CommandType.Text;
                //open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PBAException("Could not insert record!!!");
                }
            }
            catch (SqlException ex)
            {
                throw new PBAException("some error has happened!:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("some error has happened!:" + ex.Message);
            }
            finally
            { 
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Deleting the Contact By Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteContactById(int id)
        {
            try
            {
                //configure command for DELETE statement
                cmd = new SqlCommand();
                cmd.CommandText = "delete from Contact where Contactid=@id";
                cmd.CommandType = CommandType.Text;
                //Pass the value to the Parameter
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                //Attach connection to the Command
                cmd.Connection = con;
                //open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PBAException("ContactId does not exists");
                }
            }
            catch (SqlException ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Delete Category By Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCategoryById(int id)
        {
            try
            {
                //configure command for DELETE statement
                cmd = new SqlCommand();
                cmd.CommandText = "delete from ContactCategory where CategoryId=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                //pass value to Parameter
                cmd.Parameters.AddWithValue("@id", id);
                //Attach connection to the command
                cmd.Connection = con;
                //open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PBAException("CategoryId does not exists");
                }
            }
            catch (SqlException ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Displaying All Contacts By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contact> GetAllContacstById(int id)
        {
            List<Contact> lstcon = new List<Contact>();
            try
            {
                //SELECT Contact by Id
                cmd = new SqlCommand();
                cmd.CommandText = "select ContactCategory.CategoryId,Contact.ContactId,Contact.FirstName,Contact.LastName,Contact.Gender,Contact.DateOfBirth,Contact.PhoneNumber,Contact.EmailId,Contact.City,Contact.State,Contact.Country from ContactCategory join Contact on ContactCategory.CategoryId = Contact.Categoryid and Contact.CategoryId=@ci";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //configure command parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ci", id);
                //Open the connection
                con.Open();
                //Execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Contact contact = new Contact
                    {
                        //Read the record
                        ContactId = (int)sdr[0],
                        CategoryId = (int)sdr[1],
                        FirstName = sdr[2].ToString(),
                        LastName = sdr[3].ToString(),
                        Gender = sdr[4].ToString(),
                        DateOfBirth = sdr[5].ToString(),
                        PhoneNumber = Convert.ToInt64(sdr[6]),
                        EmailId = sdr[7].ToString(),
                        City = sdr[8].ToString(),
                        State = sdr[9].ToString(),
                        Country = sdr[10].ToString(),
                    };
                    lstcon.Add(contact);
                }
                //Close the reader
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            finally
            {
                //close the connection
                con.Close();
            }
            //Return the record value
            return lstcon;
        }
        /// <summary>
        /// Updating Contact By Id
        /// </summary>
        /// <param name="contact"></param>
        public void UpdateContactById(Contact contact)
        {
            try
            {
                //Update Contact By Id
                cmd = new SqlCommand();
                cmd.CommandText = "update Contact set ContactId=@ci,CategoryId=@catid,FirstName=@fname,LastName=@lname,Gender=@gen,DateOfBirth=@dob,PhoneNumber=@pn,EmailId=@eid,City=@c,State=@st,Country=@co where ContactId=@ci";
                cmd.CommandType = CommandType.Text;
                //Attach the connection command
                cmd.Connection = con;
                cmd.Parameters.Clear();
                //supply values of the parameters to the command
                cmd.Parameters.AddWithValue("@ci", contact.ContactId);
                cmd.Parameters.AddWithValue("@catid", contact.CategoryId);
                cmd.Parameters.AddWithValue("@fname", contact.FirstName);
                cmd.Parameters.AddWithValue("@lname", contact.LastName);
                cmd.Parameters.AddWithValue("@gen", contact.Gender);
                cmd.Parameters.AddWithValue("@dob", contact.DateOfBirth);
                cmd.Parameters.AddWithValue("@pn", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@eid", contact.EmailId);
                cmd.Parameters.AddWithValue("@c", contact.City);
                cmd.Parameters.AddWithValue("@st", contact.State);
                cmd.Parameters.AddWithValue("@co", contact.Country);
                //Open the connection
                con.Open();
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PBAException("ContactId does not exist");
                }
            }
            catch (SqlException ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("some error has happened" + ex.Message);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }
        /// <summary>
        /// Updating the Category By Id
        /// </summary>
        /// <param name="cat"></param>
        public void UpdateCategoryById(ContactCategory cat)
        {
            try
            {
                //Update the Category By Id
                cmd = new SqlCommand();
                cmd.CommandText = "update ContactCategory set CategoryId=@catid,CategoryName=@catname where CategoryId=@ci";
                cmd.CommandType = CommandType.Text;
                //Attach the connection to the command
                cmd.Connection = con;
                cmd.Parameters.Clear();
                //Supply values of the Parameters to the command
                cmd.Parameters.AddWithValue("@catid", cat.CategoryId);
                cmd.Parameters.AddWithValue("@ci", cat.CategoryName);
                //Open the connection
                con.Open();
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new PBAException("Could not update category");
                }
            }
            catch (SqlException ex)
            {
                throw new PBAException("Some error has happened" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PBAException("Some error has happened" + ex.Message);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }
    }
}
