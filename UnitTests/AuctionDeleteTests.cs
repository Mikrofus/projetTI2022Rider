namespace TestProject1;

public class AuctionDeleteTests
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
        var input = 1;

        
        var result = _auctionService.Execute(input);

        
        var expected = _mapper.Map<DtoOutputAuction>(_auctionRepository.Delete(input));

        
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void TestExecuteWithInvalidId()
    {
        var input = -1;
        
        var result = _auctionService.Execute(input);
        
        var expected = null;
        
        Assert.AreEqual(expected, result);
    }


}