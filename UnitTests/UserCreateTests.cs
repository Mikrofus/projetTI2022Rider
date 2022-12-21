namespace TestProject1;

public class UserCreateTests
{
        private UserService _userService;
        private IUserRepository _userRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            // Initialisation _userRepository et _mapper ici
            _userService = new UserService(_userRepository, _mapper);
        }

        [Test]
        public void TestExecuteWithValidInput()
        {
            // Création la donnée de test pour l'input DtoInputCreateUser
            var input = new DtoInputCreateUser
            {
                Pseudo = "test_user",
                Mail = "test@example.com",
                Pass = "test_pass"
            };

            // Appel de la méthode Execute avec la donnée de test en tant qu'input
            var result = _userService.Execute(input);

            // Création une valeur attendue pour le résultat
            var expected = _mapper.Map<DtoOutputUser>(_userRepository.Create(input.Pseudo, input.Mail, input.Pass));

            // teste que le résultat de la méthode est égal à la valeur attendue
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestExecuteWithInvalidInput()
        {
            // Création la donnée de test pour l'input DtoInputCreateUser avec des données d'input non valides (un pseudo vide)
            var input = new DtoInputCreateUser
            {
                Pseudo = "", // Pseudo vide
                Mail = "test@example.com",
                Pass = "test_pass"
            };

            // Appel la méthode Execute avec la donnée de test en tant qu'input
            var result = _userService.Execute(input);

            // Création une valeur attendue pour le résultat (dans ce cas, nous nous attendons à ce que la méthode retourne null)
            var expected = null;

            // teste que le résultat de la méthode est égal à la valeur attendue
            Assert.AreEqual(expected, result);
        }
}