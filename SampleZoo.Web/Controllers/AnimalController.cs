using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleZoo.Core.CQRS.Animal.Request.Commands;
using SampleZoo.Core.CQRS.Animal.Request.Queries;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.WebApi.Controllers
{
    /// <summary>
    /// مدیریت حیوانات
    /// </summary>
    public class AnimalController : BaseApiController<AnimalListDto>
    {
        #region constructor

        private readonly IMediator _mediator;
        public AnimalController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        #endregion

        #region get list

        /// <summary>
        /// به دست آوردن لیست حیوانان
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        => ReturnList(await _mediator.Send(new GetAllAnimalsQueryModel()));

        #endregion

        #region get by id

        /// <summary>
        /// به دست آوردن یک حیوان
        /// </summary>
        /// <param name="query"></param>
        /// <returns>اطلاعات حیوان</returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        => ReturnSingle(await _mediator.Send(new GetAnimalByIdQueryModel() { Id = id }));

        #endregion

        #region create

        /// <summary>
        /// افزودن حیوان
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnimalCommandModel command)
        {
            await _mediator.Send(command);
            return ReturnCreatedResult();
        }

        #endregion

        #region update

        /// <summary>
        /// بروزرسانی حیوان
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnimalCommandModel command)
        {
            await _mediator.Send(command);
            return ReturnUpdatedResult();
        }

        #endregion

        #region delete

        /// <summary>
        /// حذف حیوان
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAnimalCommandModel command)
        {
            await _mediator.Send(command);
            return DeletedUpdatedResult();
        }

        #endregion
    }
}
