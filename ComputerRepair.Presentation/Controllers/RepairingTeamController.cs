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
    public class RepairingTeamController : ControllerBase
    {
        // GET: api/<RepairingTeamController>

        private readonly IRepairingTeamService _repairingTeamService ;
        private readonly IRepairingTeamRepository _repairingTeamRepository ;
        private readonly IMapper _mapper;
        public RepairingTeamController(IRepairingTeamService  repairingTeamService,
                               IRepairingTeamRepository repairingTeamRepository, IMapper mapper)
        {

            _repairingTeamService = repairingTeamService;
            _repairingTeamRepository = repairingTeamRepository;
            _mapper = mapper;

        }

        //
        [HttpGet("{Id}")]
        public ActionResult<RepairingTeamReadDto> Get(int Id)
        {
            var repairingTeam = _repairingTeamService.GetByIdAsync(Id);
            // Destination --> Source
            var repairingTeamReadDto = _mapper.Map<RepairingTeamReadDto>(repairingTeam);
            return Ok(repairingTeamReadDto);
        }

        //
        [HttpPost]
        public void Add(RepairingTeam  repairingTeam)
        {
            _repairingTeamService.AddAsync(repairingTeam);
        }
        //

        //
        [HttpPost]
        public ActionResult<RepairingTeamCreateDto> Post(RepairingTeamCreateDto repairingTeams)
        {
            //Map CreatedDto to payement
            var CreatedRepairingTeam = _mapper.Map<RepairingTeam>(repairingTeams);
            //Create Payement
            var createdRepairingTeamService = _repairingTeamService.AddAsync(CreatedRepairingTeam);
            //Map payement to Read Dto
            var repairingServiceCreateDto = _mapper.Map<RepairingTeamCreateDto>(createdRepairingTeamService);

            return Ok(CreatedRepairingTeam);
        }

        //----
        [HttpPut]
        public ActionResult<RepairingTeamCreateDto> Update(RepairingTeamCreateDto repairingTeam)
        {

            var repairingTeamtoUpdateDto = _mapper.Map<RepairingTeam>(repairingTeam);

            var _repairingTeam = _repairingTeamService.UpdateAsync(repairingTeamtoUpdateDto);

            var reviewCreateDto = _mapper.Map<RepairingTeamCreateDto>(_repairingTeam);

            return Ok(_repairingTeam);
        }

        //-----
        [HttpDelete]
        public void Delete(RepairingTeam repairingTeam)
        {
            _repairingTeamService.DeleteAsync(repairingTeam);
        }
        //-----


    }
}
