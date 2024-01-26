using Domain.Contracts.UseCases.AddCustomer;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;
using WebApi.Models.Error;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCase;
        private readonly IValidator<AddCustomerInput> _addCustomerInputValidator;

        public AddCustomerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> addCustomerInputValidator)
        {
            _addCustomerUseCase = addCustomerUseCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerInput input)
        {
            var validationResult = _addCustomerInputValidator.Validate(input);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToCustomValidationFailure());
            }

            var customer = new Customer(input.Name, input.Email, input.Document);

            var retorno = await _addCustomerUseCase.AddCustomer(customer);

            if (retorno <= 0)
                return BadRequest("Ocorreu um erro ao tentar salvar no banco de dados.");

            return Created("", customer);
        }
    }
}
