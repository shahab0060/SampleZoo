using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleZoo.Core.CQRS.User.Handlers.Commands;
using SampleZoo.Core.CQRS.User.Request.Commands;
using SampleZoo.Core.CQRS.User.Request.Queries;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.WebApi.Controllers
{
    /// <summary>
    /// مدیریت کاربر ها
    /// </summary>
    public class UserController : BaseApiController<UserListDto>
    {
        #region constructor

        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        #endregion

        #region get list

        /// <summary>
        /// به دست آوردن لیست کاربران
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        => ReturnList(await _mediator.Send(new GetAllUsersQueryModel()));

        #endregion

        #region get by id

        /// <summary>
        /// به دست آوردن یک کاربر
        /// </summary>
        /// <param name="query"></param>
        /// <returns>اطلاعات کاربر</returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        => ReturnSingle(await _mediator.Send(new GetUserByIdQueryModel() { Id=id}));

        #endregion

        #region create

        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommandModel command)
        {
            await _mediator.Send(command);
            return ReturnCreatedResult();
        }

        #endregion

        #region update

        /// <summary>
        /// بروزرسانی کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommandModel command)
        {
            await _mediator.Send(command);
            return ReturnUpdatedResult();
        }

        #endregion

        #region delete

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserCommandModel command)
        {
            await _mediator.Send(command);
            return DeletedUpdatedResult();
        }

        #endregion
    }
}
