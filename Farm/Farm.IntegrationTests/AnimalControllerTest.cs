using Farm.Requests;
using Farm.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;

namespace Farm.IntegrationTests
{
    public class AnimalControllerTest
    {
        private readonly WebApplicationFactory<Program> _appFactory;

        public AnimalControllerTest()
        {
            _appFactory = new();
        }

        [Fact]
        public async Task Get_ReturnsAnimals()
        {
            var animalService = _appFactory.Services.GetRequiredService<IAnimalService>();
            animalService.Add("Cow");
            animalService.Add("Sheep");

            var client = _appFactory.CreateClient();
            var actual = await client.GetFromJsonAsync<string[]>("/api/animal");

            Assert.NotNull(actual);
            Assert.Contains("Cow", actual);
            Assert.Contains("Sheep", actual);
        }

        [Fact]
        public async Task Post_AddsAnimal()
        {
            var animalService = _appFactory.Services.GetRequiredService<IAnimalService>();

            var client = _appFactory.CreateClient();
            var result = await client.PostAsJsonAsync("/api/animal", new AddAnimalRequest { Name = "Cow" });
            result.EnsureSuccessStatusCode();

            var animals = animalService.GetAnimals();
            Assert.Contains("Cow", animals);
        }

        [Fact]
        public async Task Post_ReturnsBadRequestWhenAnimalNameIsEmpty()
        {
            var client = _appFactory.CreateClient();
            var result = await client.PostAsJsonAsync("/api/animal", new AddAnimalRequest());
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task Post_ReturnsConflictWhenCreatingDuplicateAnimal()
        {
            var animalService = _appFactory.Services.GetRequiredService<IAnimalService>();
            animalService.Add("Cow");

            var client = _appFactory.CreateClient();
            var result = await client.PostAsJsonAsync("/api/animal", new AddAnimalRequest { Name = "Cow" });

            Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundWhenDeletingNonExistentAnimal()
        {
            var client = _appFactory.CreateClient();
            var result = await client.DeleteAsync("/api/animal/Cow");

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task Delete_DeletesAnimal()
        {
            var animalService = _appFactory.Services.GetRequiredService<IAnimalService>();
            animalService.Add("Cow");
            animalService.Add("Sheep");

            var client = _appFactory.CreateClient();
            var result = await client.DeleteAsync("/api/animal/Sheep");
            result.EnsureSuccessStatusCode();

            var animals = animalService.GetAnimals();
            Assert.Contains("Cow", animals);
            Assert.DoesNotContain("Sheep", animals);
        }
    }
}