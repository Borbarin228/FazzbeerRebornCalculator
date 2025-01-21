using FazzbeerRebornCalculator;

namespace FazzbeerRebornCalculatorTest
{
    public class MainPageViewModelTest
    {
        [Fact]
        public void add3Test()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = "0";
            viewModel.result = viewModel.addNum(viewModel.result, "3");
            Assert.Equal("3", viewModel.result);
        }
        [Fact]
        public void add32Test()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = "3";
            viewModel.result = viewModel.addNum(viewModel.result, "2");
            Assert.Equal("32", viewModel.result);
        }
        //[Fact]
        //public void addPlus12()
        //{
        //    viewModel.status = MainPageViewModel
        //}

        [Fact]
        public void add12Test()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = "3";
            viewModel.result = viewModel.addNum(viewModel.result, "2");
            Assert.Equal("32", viewModel.result);
        }
        [Fact]

        public void plus12Test()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = viewModel.addNum(viewModel.result, "1");
            viewModel.result = viewModel.addNum(viewModel.result, "2");
            viewModel.operations = "";
            viewModel.status = MainPageViewModel.Status.None;
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, viewModel.status);
            Assert.Equal("12", viewModel.operations);
        }
        [Fact]
        public void plus5And3()
        {

            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = "0";
            viewModel.result = viewModel.addNum(viewModel.result, "3");

            viewModel.operations = "5";
            viewModel.status = MainPageViewModel.Status.Plus;
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, viewModel.status);
            viewModel.status = MainPageViewModel.Status.None;
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, viewModel.status);

            Assert.Equal("11", viewModel.operations);
        }
        [Fact]
        public void doubleEqualTest()
        {
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.result = viewModel.addNum(viewModel.result, "3");
            viewModel.result = viewModel.addNum(viewModel.result, "4");
            viewModel.operations = "12";
            viewModel.status = MainPageViewModel.Status.Plus;
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, viewModel.status);
            viewModel.status = MainPageViewModel.Status.None;
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, viewModel.status);
            viewModel.status = MainPageViewModel.Status.None;
            viewModel.operations = viewModel.parseOperation(viewModel.operations, viewModel.result, viewModel.status);
            Assert.Equal("80", viewModel.operations);
        }
    }
}