using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using todoapp.model;
using todoapp.model.core;

namespace todoapp.specs.Steps
{
    [Binding]
    public class AddTodoItemSteps
    {

        [Given(@"I write (.*) into the application")]
        public void GivenIWriteIntoTheApplication(string todoContents)
        {
            var holidayCheck = MockRepository.GenerateStub<IHolidayCheckerService>();
            var app = new TodoApplication(holidayCheck);

            ScenarioContext.Current.Add("app", app);
            ScenarioContext.Current.Add("contents", todoContents);
            ScenarioContext.Current.Add("holidayChecker", holidayCheck);

        }

        [Given(@"It is a Holiday")]
        public void GivenItIsAHoliday()
        {
            var holidayChecker = ScenarioContext.Current.Get<IHolidayCheckerService>("holidayChecker");
            holidayChecker.Stub(x => x.IsHoliday()).Return(true);
        }

        [When(@"I add the TodoItem")]
        public void WhenIAddTheTodoItem()
        {
            var app = ScenarioContext.Current.Get<TodoApplication>("app");

            var contents = ScenarioContext.Current.Get<string>("contents");
            var item = new TodoItem();
            item.Contents = contents;

            app.Add(item);
        }

        [Then(@"the result should be (.*) todo items")]
        public void ThenTheResultShouldBeTodoItems(int count)
        {
            var app = ScenarioContext.Current.Get<TodoApplication>("app");
            Assert.AreEqual(count, app.TodoItems.Count);
        }

     
    }
}
