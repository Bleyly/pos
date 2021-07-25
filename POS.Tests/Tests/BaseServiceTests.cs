using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS.Data;
using POS.Service;
using Xunit;

namespace POS.Tests
{
    public sealed class BaseServiceTests : Config
    {
        private readonly IService<Color> _colorService;

        public BaseServiceTests()
        {
            ColorSeed.Seed(_context);
            _colorService = new BaseService<Color>(_unitOfWork);
        }

        [Fact]
        public async Task WhenCallingGetAllAsync_Expect5Colors()
        {
            // arrange
            int expectedColors = 5;

            // act
            IEnumerable<Color> colors = await _colorService.GetAllAsync();

            // assert
            Assert.Equal(expectedColors, colors.Count());
        }

        [Fact]
        public async Task WhenCallingGetAsync_ExpectAColor()
        {
            // arrange
            var expectedColor = new Color
            {
                Description = $"Color #1",
                Hexadecimal = $"#000",
                Id = 1,
                Name = $"Color #1",
            };

            // act
            Color color = await _colorService.GetAsync(expectedColor.Id);

            // assert
            Assert.Equal(expectedColor, color, new ColorComparer());
        }

        [Fact]
        public async Task WhenCallingCreateAsync_Expect6Colors()
        {
            int expectedColors = 6;
            var expectedColor = new Color
            {
                Description = $"Color #6",
                Hexadecimal = $"#005",
                Name = $"Color #6",
            };

            await _colorService.CreateAsync(expectedColor);

            IEnumerable<Color> colors = await _colorService.GetAllAsync();

            Assert.Equal(expectedColors, colors.Count());
            Assert.Equal(expectedColor, colors.Last(), new ColorComparer());
        }

        [Fact]
        public async Task WhenCallingUpdateAsync_ExpectNewColorName()
        {
            string expectedName = "Color";
            int colorId = 1;

            var color = await _colorService.GetAsync(colorId);
            color.Name = expectedName;

            await _colorService.UpdateAsync(color);

            var DbColor = await _colorService.GetAsync(colorId);

            Assert.Equal(expectedName, DbColor.Name);
        }

        [Fact]
        public async Task WhenCallingDeleteAsync_Expect4Colors()
        {
            int expectedColors = 4;
            int colorId = 1;

            await _colorService.DeleteAsync(colorId);
            var colors = await _colorService.GetAllAsync();

            Assert.Equal(expectedColors, colors.Count());
        }
    }
}