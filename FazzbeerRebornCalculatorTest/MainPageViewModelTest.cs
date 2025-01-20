using FazzbeerRebornCalculator;

namespace FazzbeerRebornCalculatorTest
{
    public class MainPageViewModelTest
    {
        [Fact]
        public void addNumTest()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = "1";
            viewModel.result = viewModel.addNum(viewModel.result, "2");
            Assert.Equal("12", viewModel.result);
        }
        [Fact]
        public void ParseTest()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.operations = "2";
            viewModel.result = "4";
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, MainPageViewModel.Status.Minus);
            Assert.Equal(viewModel.operations, "-2");
        }
    }
}