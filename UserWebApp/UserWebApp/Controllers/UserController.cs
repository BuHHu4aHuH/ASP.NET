namespace UserWebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using UserWebApp.Models;
    using UserWebApp.Models.Domain;

    public class UserController : Controller
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController()
        {
            this.context = new DatabaseContext();
        }

        public ActionResult Index() {

            this.ViewBag.InfoForPartial = "User list";
            /*
            var list = this.context.Items.Select(
                e => new UserDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    dateOfBirthday = e.birthdayData
                }).ToList();
                */
            var list = new List<UserDto>{
                new UserDto{Id = 1, Name = "Пользователь", dateOfBirthday = DateTime.Now}
            };

            return this.View(list);
        }

        public ActionResult Create()
        {
            this.ViewBag.InfoForPartial = "Create new";

            return this.View();
        }

    }
}
