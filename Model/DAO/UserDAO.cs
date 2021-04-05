using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnnewsNews.Common;

namespace Model.DAO
{
    public class UserDAO
    {
        private DBvnewsEntities db = new DBvnewsEntities();

        public int LoginWithAccount(string email, string password)
        {
            try
            {
                var pass = Encryptor.MD5Hash(password);
                var result = db.Users.FirstOrDefault(t => t.user_email == email && t.user_password == pass);
                if(result != null)
                {
                    if(result.user_bin == true)
                    {
                        // khong ton tai
                        return -1;
                    }
                    else if(result.user_active == false)
                    {
                        // da bi khoa
                        return -2;
                    }
                    else
                    {
                        db.Users.Find(result.user_id).user_datelogin = DateTime.Now;
                        db.SaveChanges();
                        // thanh cong
                        return 1;
                    }
                }
                else
                {
                    // sai tai khoan hoac mat khau
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }
        public int Insert(User user)
        {
            try
            {
                if(db.Users.FirstOrDefault(t => t.user_email == user.user_email) != null)
                {
                    // email da ton tai
                    return -1;
                }
                else
                {
                    user.user_image = "/Images/Users/blank-profile-picture-973460_640.png";
                    user.user_active = true;
                    user.user_bin = false;
                    user.user_datecreate = DateTime.Now;
                    user.user_datelogin = DateTime.Now;
                    user.user_password = Encryptor.MD5Hash(user.user_password);
                    user.role_id = 4;
                    db.Users.Add(user);
                    db.SaveChanges();

                    // thanh cong
                    return 1;
                }
            }
            catch (Exception) { return 0; }
        }

        public bool ResetPassword(int id, string NewPassword)
        {
            try
            {
                db.Users.Find(id).user_password = Encryptor.MD5Hash(NewPassword);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
