using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComputerRepair.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairingTypeController : ControllerBase
    {
        private readonly IRepairingTypeService  _repairingTypeService;
        private readonly IRepairingTypeRepository _repairingTypeRepository;
        private readonly IMapper _mapper;
        public RepairingTypeController(IRepairingTypeService  repairingTypeService,
                               IRepairingTypeRepository repairingTypeRepository, IMapper mapper)
        {

            _repairingTypeService = repairingTypeService;
            _repairingTypeRepository = repairingTypeRepository;
            _mapper = mapper;

        }

        //
        [HttpGet("{Id}")]
        public ActionResult<RepairingTypeReadDto> Get(int Id)
        {
            var repairingType = _repairingTypeService.GetByIdAsync(Id);
            // Destination --> Source
            var repairingTypeReadDto = _mapper.Map<RepairingTeamReadDto>(repairingType);
            return Ok(repairingTypeReadDto);
        }

        //--
        [HttpPost]
        public void Add(RepairingType repairingType)
        {
            _repairingTypeService.AddAsync(repairingType);
        }
        //--

        //
        [HttpPost]
        public ActionResult<RepairingTypeCreateDto> Post(RepairingTypeCreateDto repairingTypes)
        {
            //Map CreatedDto to payement
            var CreatedRepairingType = _mapper.Map<RepairingType>(repairingTypes);
            //Create Payement
            var createdRepairingTypeService = _repairingTypeService.AddAsync(CreatedRepairingType);
            //Map payement to Read Dto
            var repairingServiceCreateDto = _mapper.Map<RepairingTypeCreateDto>(createdRepairingTypeService);

            return Ok(CreatedRepairingType);

        }

        //----
        [HttpPut]
        public ActionResult<RepairingTypeCreateDto> Update(RepairingTypeCreateDto repairingType)
        {

            var repairingTypetoUpdateDto = _mapper.Map<RepairingType>(repairingType);

            var _repairingType = _repairingTypeService.UpdateAsync(repairingTypetoUpdateDto);

            var reviewCreateDto = _mapper.Map<RepairingTypeCreateDto>(_repairingType);

            return Ok(_repairingType);
        }

        //-----
        [HttpDelete]
        public void Delete(RepairingType repairingType)
        {
            _repairingTypeService.DeleteAsync(repairingType);
        }
        //-----


    }
}
