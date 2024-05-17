using InterviewProject.Service.DTO;
using InterviewProject.Service.Service.Interface;
using InterviewProject.Service.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace InterviewProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contatoService;
        private readonly ILogger<ContactController> _logger;
        private readonly IMapper _mapper;

        public ContactController(ILogger<ContactController> logger, IContactService contact, IMapper mapper)
        {
            _contatoService = contact;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _contatoService.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ContactDTO contact)
        {
            try
            {

                return Ok(await _contatoService.Add(_mapper.Map<ViewModelContact>(contact)));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("Change/{id:guid}")]
        public async Task<IActionResult> Change([FromBody] ViewModelContact obj)
        {
            try
            {
                return Ok(await _contatoService.Change(obj));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("Desactive/{id:guid}")]
        public async Task<IActionResult> Desactive([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _contatoService.Desactive(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("ReturnById/{id:guid}")]
        public async Task<IActionResult> ReturnById([FromRoute] Guid id)
        {
            return Ok(await _contatoService.ReturnById(id));
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _contatoService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
