using System.Diagnostics;
using Application.UseCases.Auction;

namespace TestProject1;

public class AuctionServiceTests
{
        private AuctionService _auctionService;
        private IAuctionRepository _auctionRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            
            _auctionService = new AuctionService(_auctionRepository, _mapper);
        }

        [Test]
        public void TestExecuteWithValidInput()
        {
            
            var input = new DtoInputCreateAuction
            {
                IdUser = 1,
                Title = "Test Auction",
                Category = "Test Category",
                Descri = "Test Description",
                Img = "test.jpg",
                Price = 100,
                IdUserBid = 2,
                Timer = 10
            };

            
            var result = _auctionService.Execute(input);

            
            var expected = _mapper.Map<DtoOutputAuction>(
                _auctionRepository.Create(input.IdUser, input.Title, input.Category, input.Descri, input.Img,
                    input.Price, input.IdUserBid, input.Timer)
            );
            
            Assert.AreEqual(expected, result);
        }
        
}    
