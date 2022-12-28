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
    public class ReviewController : ControllerBase
    {
        // GET: api/<ReviewController>
        private readonly IReviewService _reviewService;
        //private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService,
                               IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewService = reviewService;
           // _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        //
        [HttpGet("{Id}")]
        public ActionResult<ReviewReadDto> Get(int Id)
        {
            var review = _reviewService.GetByIdAsync(Id);
            // Destination --> Source
            var reviewReadDto = _mapper.Map<ReviewReadDto>(review);
            return Ok(reviewReadDto);
        }

        //
        [HttpPost]
        public void Add(Review review)
        {
            _reviewService.AddAsync(review);
        }
        //
        //
        [HttpPost]
        public ActionResult<ReviewCreateDto> Post(ReviewCreateDto reviews)
        {
            //Map CreatedDto to review
            var CreatedReview = _mapper.Map<Review>(reviews);

            //Create Review
            var createdReviewService = _reviewService.AddAsync(CreatedReview);

            //Map review to Read Dto
            var orderCreateDto = _mapper.Map<OrderCreateDto>(createdReviewService);

            return Ok(CreatedReview);
        }

        //----
        [HttpPut]
        public ActionResult<ReviewCreateDto> Update(ReviewCreateDto review)
        {

            var reviewtoUpdateDto = _mapper.Map<Review>(review);

            var _review = _reviewService.UpdateAsync(reviewtoUpdateDto);

            var reviewCreateDto = _mapper.Map<ReviewCreateDto>(_review);

            return Ok(_review);
        }

        //-----
        [HttpDelete]
        public void Delete(Review review)
        {
            _reviewService.DeleteAsync(review);
        }
        //-----


    }
}
