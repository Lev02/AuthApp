using AuthApp.Core.Models;
using AuthApp.DAL.Services;

namespace AuthApp.DAL.Tests
{
    public class UserServicePetstoreTests
    {
        private UserService _userService;
        private User _moqUser;

        [SetUp]
        public void Setup()
        {
            // Инициализация реального HttpClient
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://petstore.swagger.io")
            };
            _userService = new UserService(httpClient);
            _moqUser = new User
            {
                FirstName = "ijbifgbikgfbokdof",
                LastName = "dfogdfpllgpdflgpldfg",
                Email = "dofdogkdfgoreo@example.com",
                Phone = "+1234567890",
                Username = "dsfsdofodskoodspllsddf",
                Password = "sodfsdflsdofpsdplepllsdplv"
            };
        }

        [Test]
        public async Task RegisterUserAsync_ShouldReturnTrue_WhenUserIsRegisteredSuccessfully()
        {
            // Act
            var result = await _userService.RegisterUserAsync(_moqUser);

            // Assert
            Assert.IsTrue(result, "Пользователь должен быть успешно зарегистрирован.");
        }

        [Test]
        public async Task GetUserByLoginAsync_ShouldReturnUser_WhenUserExists()
        {
            // Act
            var user = await _userService.GetUserByLoginAsync(_moqUser.Username);

            // Assert
            Assert.IsNotNull(user, "Пользователь должен быть получен.");
            Assert.That(user?.Username, Is.EqualTo(_moqUser.Username), "Имя пользователя должно совпадать.");
        }

        [Test]
        public async Task LoginAsync_ShouldReturnTrue_WhenCredentialsAreCorrect()
        {
            // Act
            var result = await _userService.LoginAsync(_moqUser.Username, _moqUser.Password);

            // Assert
            Assert.IsTrue(result, "Пользователь должен быть успешно авторизован.");
        }

        [Test]
        public async Task LogoutAsync_ShouldReturnTrue_WhenUserLogsOutSuccessfully()
        {
            // Act
            var result = await _userService.LogoutAsync();

            // Assert
            Assert.IsTrue(result, "Пользователь должен быть успешно разлогинен.");
        }
    }
}