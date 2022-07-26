using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MiSchool.Classes;

namespace MiSchool.Classes
{
    public class Factory
    {
        #region GeneralCommands

        /// <summary>
        /// Command for logging in
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool Login(string UserName,string Password)
        {
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param[0].Value = UserName;

                var dt = new DataAccessLayer().SelectParameter("select * from tblUsers where UserName=@UserName", param);

                if (dt.Rows.Count > 0)
                {
                    // read data from database if we found any user

                    string dbPassword = Convert.ToString(dt.Rows[0]["UserPassword"]);
                    string dbUserGuid = Convert.ToString(dt.Rows[0]["UserGuid"]);

                    // Now we hash the UserGuid from the database with the password we want to check
                    // In the same way as when we saved it to the database in the first place.
                    string hashedPassword = PasswordEncryption.HashSHA1(Password + dbUserGuid);

                    // if its correct password the result of the hash is the same as in the database
                    if (dbPassword == hashedPassword)
                    {
                        // The password is correct
                        Properties.Settings.Default.UserNickName = Convert.ToString(dt.Rows[0]["UserNickName"]);
                        Properties.Settings.Default.UserRole = Convert.ToString(dt.Rows[0]["UserRole"]);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("كلمة المرور خاطئة");
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("اسم المستخدم خاطئ");
                    return false;
                }


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;
            }
           

        }

        /// <summary>
        /// Comamand for verifying username 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool VeriftUserName(string UserName)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param[0].Value = UserName;

                DataAccessLayer dal = new DataAccessLayer();
                var dt = new DataAccessLayer().SelectParameter("select UserId from tblUsers where UserName=@UserName", param);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
           
        }


        #endregion



        #region InsertCommands

        public void AddUser(string UserName, string UserPassword,string UserNickName,string UserRole)
        {
            try
            {
                // First create a new Guid for the user. This will be unique for each user
                Guid UserGuid = System.Guid.NewGuid();

                // Hash the password together with our unique userGuid
                string hashedPassword = PasswordEncryption.HashSHA1(UserPassword + UserGuid.ToString());

                DataAccessLayer dal = new DataAccessLayer();
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param[0].Value = UserName;

                param[1] = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
                param[1].Value = hashedPassword;

                param[2] = new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier);
                param[2].Value = UserGuid;


                param[3] = new SqlParameter("@UserNickName", SqlDbType.NVarChar, 50);
                param[3].Value = UserNickName;


                param[4] = new SqlParameter("@UserRole", SqlDbType.VarChar, 50);
                param[4].Value = UserRole;

                dal.ExcuteCommand("insert into tblUsers(UserName,UserPassword,UserGuid,UserNickName,UserRole) Values(@UserName,@UserPassword,@UserGuid,@UserNickName,@UserRole)", param);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }

        #endregion

        #region DeleteCommands








   



  
        



        #endregion

        #region EditCommands

        public void EditUser(int UserId,string UserName, string UserPassword,string UserNickName,string UserRole)
        {
            try
            {

                DataAccessLayer dal = new DataAccessLayer();

                // First create a new Guid for the user. This will be unique for each user
                Guid UserGuid = System.Guid.NewGuid();

                // Hash the password together with our unique userGuid
                string hashedPassword = PasswordEncryption.HashSHA1(UserPassword + UserGuid.ToString());

                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param[0].Value = UserName;

                param[1] = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
                param[1].Value = hashedPassword;

                param[2] = new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier);
                param[2].Value = UserGuid;


                param[3] = new SqlParameter("@UserNickName", SqlDbType.NVarChar, 50);
                param[3].Value = UserNickName;


                param[4] = new SqlParameter("@UserId", SqlDbType.Int);
                param[4].Value = UserId;

                param[5] = new SqlParameter("@UserRole", SqlDbType.VarChar, 50);
                param[5].Value = UserRole;

                dal.ExcuteCommand("Update [tblUsers] set UserName=@UserName,UserPassword=@UserPassword,UserGuid=@UserGuid,UserNickName=@UserNickName,UserRole=@UserRole where UserId=@UserId", param);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        //public void EditUserPassword(int UserId,string UserName,string UserNickName,string UserRole)
        //{
        //    try
        //    {
        //        DataAccessLayer dal = new DataAccessLayer();

        //        SqlParameter[] param = new SqlParameter[4];

        //        param[0] = new SqlParameter("@UserId", SqlDbType.Int);
        //        param[0].Value = UserId;

        //        param[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        //        param[1].Value = UserName;


        //        param[2] = new SqlParameter("@UserNickName", SqlDbType.NVarChar, 50);
        //        param[2].Value = UserNickName;


        //        param[3] = new SqlParameter("@UserRole", SqlDbType.VarChar, 50);
        //        param[3].Value = UserRole;

        //        dal.ExcuteCommand("Update tblUsers set UserName=@UserName, UserNickName=@UserNickName, UserRole=@UserRole where UserId=@UserId", param);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }



        //}


        #endregion
    }
}
