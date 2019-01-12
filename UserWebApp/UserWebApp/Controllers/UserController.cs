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

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Create()
        {
            this.ViewBag.InfoForPartial = "Create new";

            return this.View();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Create(UserDto dto)
        {
            this.ViewBag.InfoForPartial = "Create error";

            if (!this.ModelState.IsValid)
            {
                return this.View(dto);
            }

            var model = MapToItem(dto);

            this.context.Items.Add(model);
            this.context.SaveChanges();

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Delete(int id)
        {
            var item = this.context.Items.Find(id);

            if (item == null)
            {
                return this.HttpNotFound();
            }

            var dto = MapToDto(item);

            return this.View(dto);
        }

        /// <summary>
        /// The delete post.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var item = this.context.Items.Find(id);

            if (item == null)
            {
                return this.HttpNotFound();
            }

            this.context.Items.Remove(item);
            this.context.SaveChanges();

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The map to item.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="UserItem"/>.
        /// </returns>
        private static UserItem MapToItem(UserDto dto) =>
        new UserItem
            {
                Id = dto.Id,
                Name = dto.Name,
                birthdayData = dto.dateOfBirthday
            };

        /// <summary>
        /// The map to dto.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="UserDto"/>.
        /// </returns>
        private static UserDto MapToDto(UserItem item) =>
        new UserDto
        {
                Id = item.Id,
                Name = item.Name,
                dateOfBirthday = item.birthdayData
        };
    }
}


