using Contacts.DataAccess.DBRepository;
using Contacts.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Contacts.DataAccess.DBService
{
    /// <summary>
    /// Implements the IContact interface in DA to perform operations on contacts
    /// </summary>
    public class Contacts : IContacts
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);

        /// <summary>
        /// Fetch Contact information for particular contact Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ContactDO</returns>
        public ContactDO GetContact(int id)
        {
            ContactDO contactDetails = new ContactDO();
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"SELECT * FROM TBL_Contact WHERE [Status] = True AND [Contact ID] = " + id;
                cmd.Connection = connection;
                connection.Open();

                OleDbDataAdapter ada = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                GetContactDO(contactDetails, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return contactDetails;
        }

        /// <summary>
        /// Fetch the list of all the Contacts
        /// </summary>
        /// <returns>List<ContactDO></returns>
        public List<ContactDO> GetAllContacts()
        {
            List<ContactDO> contactList = new List<ContactDO>();
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"SELECT * FROM TBL_Contact WHERE [Status] = True";
                cmd.Connection = connection;
                connection.Open();

                OleDbDataAdapter ada = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                GetContactDOList(contactList, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return contactList;
        }

        /// <summary>
        /// Add the new contact information to the database
        /// </summary>
        /// <param name="contactDetailsModel"></param>
        /// <returns>int</returns>
        public int AddContact(ContactDO item)
        {
            int rowsAffected = 0;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"Insert Into TBL_Contact([First Name], [Last Name], [Email Address], [Phone Number], [Status])VALUES('" + item.FirstName.Trim() + "', '" + item.LastName.Trim() + "', '" + item.EmailID.Trim() + "', '" + item.PhoneNumber.Trim() + "', " + true + ");";
                cmd.Connection = connection;
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Updates the existing contact information
        /// </summary>
        /// <param name="contactDetailsModel"></param>
        /// <returns>int</returns>
        public int UpdateContact(ContactDO item)
        {
            int rowsAffected = 0;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"UPDATE TBL_Contact SET [First Name] = '" + item.FirstName.Trim() + "', [Last Name] = '" + item.LastName.Trim() +
                                  "', [Email Address] = '" + item.EmailID.Trim() + "', [Phone Number] = '" + item.PhoneNumber.Trim() + 
                                  "' WHERE [Contact ID] = " + item.ContactId;

                cmd.Connection = connection;
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Deletes the existing contact information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public int DeleteContact(int id)
        {
            int rowsAffected = 0;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"UPDATE TBL_Contact SET [Status] = False WHERE [Contact ID] = " + id;
                cmd.Connection = connection;
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// To check if contact is already exists or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns>bool</returns>
        public bool CheckIfContactAlreadyExist(ContactDO item)
        {
            bool isContactExist = false;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"SELECT * FROM TBL_Contact WHERE [Status] = True AND [First Name] = '" + item.FirstName.Trim() + "' AND [Last Name] = '" + item.LastName.Trim() + "'"; 
                cmd.Connection = connection;
                connection.Open();

                OleDbDataAdapter ada = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                if(ds.Tables[0].Rows.Count > 0)
                {
                    isContactExist = true;
                }
                else
                {
                    isContactExist = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return isContactExist;
        }

        #region -- Helper Methods --

        /// <summary>
        /// Maps the data set columns to the properties of Contact DO model to get the contact information
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <param name="ds"></param>
        private void GetContactDO(ContactDO contactDetails, DataSet ds)
        {
            contactDetails.ContactId = Convert.ToInt32(ds.Tables[0].Rows[0]["Contact ID"].ToString());
            contactDetails.FirstName = ds.Tables[0].Rows[0]["First Name"].ToString();
            contactDetails.LastName = ds.Tables[0].Rows[0]["Last Name"].ToString();
            contactDetails.EmailID = ds.Tables[0].Rows[0]["Email Address"].ToString();
            contactDetails.PhoneNumber = ds.Tables[0].Rows[0]["Phone Number"].ToString();
            contactDetails.Status = Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"].ToString());
        }

        /// <summary>
        /// Maps the data set columns to the properties of Contact DO model to get the list of contacts
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="ds"></param>
        private void GetContactDOList(List<ContactDO> contactList, DataSet ds)
        {
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                ContactDO contactDetails = new ContactDO();

                contactDetails.ContactId = Convert.ToInt32(row["Contact ID"].ToString());
                contactDetails.FirstName = row["First Name"].ToString();
                contactDetails.LastName = row["Last Name"].ToString();
                contactDetails.EmailID = row["Email Address"].ToString();
                contactDetails.PhoneNumber = row["Phone Number"].ToString();
                contactDetails.Status = Convert.ToBoolean(row["Status"].ToString());

                contactList.Add(contactDetails);
            }
        }

        #endregion -- Helper Methods --
    }
}
