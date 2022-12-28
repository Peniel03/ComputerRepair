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
    public class PayementController : ControllerBase
    {
        // GET: api/<PayementController>

        private readonly IPayementService _payementService;
        private readonly IPayementRepository _payementRepository;
        private readonly IMapper _mapper;
        public PayementController(IPayementService payementService,
                               IPayementRepository payementRepository, IMapper mapper)
        {
            _payementService = payementService;
            _payementRepository = payementRepository;
            _mapper = mapper;
        }

        //
        [HttpGet("{Id}")]
        public ActionResult<PayementReadDto> Get(int Id)
        {
            var payement = _payementService.GetByIdAsync(Id);
            // Destination --> Source
            var payementReadDto = _mapper.Map<PayementReadDto>(payement);
            return Ok(payementReadDto);
        }

        //
        [HttpPost]
        public void Add(Payement payement)
        {
            _payementService.AddAsync(payement);
        }
        //

        //
        [HttpPost]
        public ActionResult<PayementCreateDto> Post(PayementCreateDto payements)
        {
            //Map CreatedDto to payement
            var CreatedPayement = _mapper.Map<Payement>(payements);

            //Create Payement
            var createdReviewService = _payementService.AddAsync(CreatedPayement);

            //Map payement to Read Dto
            var payementCreateDto = _mapper.Map<OrderCreateDto>(createdReviewService);

            return Ok(CreatedPayement); 
        }

        //----
        [HttpPut]
        public ActionResult<PayementCreateDto> Update(PayementCreateDto payement)
        {

            var reviewtoUpdateDto = _mapper.Map<Payement>(payement);

            var _payement = _payementService.UpdateAsync(reviewtoUpdateDto);

            var reviewCreateDto = _mapper.Map<ReviewCreateDto>(_payement);

            return Ok(_payement);
        }

        //-----
        [HttpDelete]
        public void Delete(Payement payement)
        {
            _payementService.DeleteAsync(payement);
        }
        //-----


    }
}
