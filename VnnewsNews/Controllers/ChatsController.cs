using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using VnnewsNews.Function;
using VnnewsNews.Hubs;

namespace VnnewsNews.Controllers
{
    public class ChatsController : Controller
    {
        DBvnewsEntities db = new DBvnewsEntities();
        FunctionsController functions = new FunctionsController();
        // GET: Chats
        public ActionResult ChatAll()
        {
            return View();
        }
        public PartialViewResult ChatAlltest()
        {
            return PartialView();
        }
        public JsonResult GetAll()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBvnews"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [chat_id],[chat_content],[user_id],[chat_key],[chat_item],[chat_datecreate]FROM [dbo].[Chats]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var listChat = from item in db.Chats
                                   where item.chat_item == Common.Common.CHAT_ALL
                                   orderby item.chat_datecreate descending
                                   select new
                                   {
                                       id = item.chat_id,
                                       idus = item.user_id,
                                       content = item.chat_content,
                                       date = item.chat_datecreate,
                                       key = item.chat_key
                                   };

                    return Json(new { listChat = listChat }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            ChatHub.Show();
        }
        public JsonResult PostChat(string content)
        {
            Chat chat = new Chat()
            {
                chat_content = content,
                chat_datecreate = DateTime.Now,
                chat_item = Common.Common.CHAT_ALL,
                user_id = functions.CookieID().user_id
            };
            db.Chats.Add(chat);
            db.SaveChanges();
            return Json(null);
        }
    }
}