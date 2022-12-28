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
    public class RepairingServiceController : ControllerBase
    {
        // GET: api/<RepairingServiceController>

        private readonly IRepairingServiceService _repairingServiceService;
        private readonly IRepairingServiceRepository  _repairingServiceRepository;
        private readonly IMapper _mapper;
        public RepairingServiceController(IRepairingServiceService repairingServiceService,
                               IRepairingServiceRepository repairingServiceRepository, IMapper mapper)
        {
            _repairingServiceService = repairingServiceService;
            _repairingServiceRepository = repairingServiceRepository;
            _mapper = mapper;
        }

        //
        [HttpGet("{Id}")]
        public ActionResult<RepairingServiceReadDto> Get(int Id)
        {
            var repairingService = _repairingServiceService.GetByIdAsync(Id);
            // Destination --> Source
            var repairingServiceReadDto = _mapper.Map<RepairingServiceReadDto>(repairingService);
            return Ok(repairingServiceReadDto);
        }

        //
        [HttpPost]
        public void Add(RepairingService repairingService)
        {
            _repairingServiceService.AddAsync(repairingService);
        }
        //

        //
        [HttpPost]
        public ActionResult<RepairingServiceCreateDto> Post(RepairingServiceCreateDto repairingServices)
        {
            //Map CreatedDto to payement
            var CreatedRepairingService = _mapper.Map<RepairingService>(repairingServices);
            //Create Payement
            var createdRepairingServiceService = _repairingServiceService.AddAsync(CreatedRepairingService);
            //Map payement to Read Dto
            var repairingServiceCreateDto = _mapper.Map<RepairingServiceCreateDto>(createdRepairingServiceService);

            return Ok(CreatedRepairingService);
        }

        //----
        [HttpPut]
        public ActionResult<RepairingServiceCreateDto> Update(RepairingServiceCreateDto repairingService)
        {

            var repairingServicetoUpdateDto = _mapper.Map<RepairingService>(repairingService);

            var _repairingService = _repairingServiceService.UpdateAsync(repairingServicetoUpdateDto);

            var reviewCreateDto = _mapper.Map<RepairingServiceCreateDto>(_repairingService);

            return Ok(_repairingService);
        }

        //-----
        [HttpDelete]
        public void Delete(RepairingService repairingService)
        {
            _repairingServiceService.DeleteAsync(repairingService);
        }
        //-----



    }
}
