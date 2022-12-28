using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.RepositoryServices
{
    public class ReviewService: IReviewService
    {
        public readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;

        }

        public async Task<Review> AddAsync(Review review)
        {
            var reviewLooked = _reviewRepository.GetByIdAsync(review.ReviewId);

            if (reviewLooked is not null)
            {
                throw new ExistException("This review already exist");
            }

            _reviewRepository.Add(review);
            await _reviewRepository.SavechangesAsync();

            return review;
        }

        public async Task<Review> DeleteAsync(Review review)
        {
            var reviewLooked = await _reviewRepository.GetByIdAsync(review.ReviewId);

            if (reviewLooked is null)
            {
                throw new NotFoundException("This Review does not exist");
            }
            _reviewRepository.DeleteAsync(reviewLooked);
            await _reviewRepository.SavechangesAsync();
            return review;

        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();

            if (reviews is null)
            {
                throw new NotFoundException("There are no review  yet");
            }
            return  reviews;
        }

        public async Task<Review?> GetByIdAsync(int Id)
        {
            var review = await _reviewRepository.GetByIdAsync(Id);

            if (review is null)
            {
                throw new NotFoundException("No review found with the corresponding Id");
            }

            return review;
        }

        public async Task<Review?> GetByRate(int rate)
        {
            var review = await _reviewRepository.GetByRate(rate);

            if (review is null)
            {
                throw new NotFoundException("No review found with corresponding Rate");
            }

            return review;
        }

        public Task SavechangesAsync()
        {
            return _reviewRepository.SavechangesAsync();
         }

        public async Task<Review> UpdateAsync(Review review)
        {
            var reviewLooked = await _reviewRepository.GetByIdAsync(review.ReviewId);

            if (reviewLooked is null)
            {
                throw new NotFoundException("The review does not exist");
            }

            reviewLooked.ReviewField = review.ReviewField;
            reviewLooked.Rate = review.Rate;
            _reviewRepository.UpdateAsync(reviewLooked);
            await _reviewRepository.SavechangesAsync();

            return review;
        }
    }
}
