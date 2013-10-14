using NUnit.Framework;
using Rhino.Mocks;
using todoapp.model;
using todoapp.model.core;

namespace todoapp.specs.Tests
{
    [TestFixture]
    public class AddItemTests
    {
        [Test]
        public void ApplicationShouldCheckIfTodayIsAHolidayWhenAddingTheItem()
        {
            var holidayCheck = MockRepository.GenerateStub<IHolidayCheckerService>();
            holidayCheck.Stub(x => x.IsHoliday()).Return(true);

            var app = new TodoApplication(holidayCheck);
            var item = new TodoItem {Contents = "call mom tomorrow"};
            app.Add(item);

            Assert.AreEqual(0, app.TodoItems.Count);

            holidayCheck.AssertWasCalled(x=>x.IsHoliday());
        }

    }
}
