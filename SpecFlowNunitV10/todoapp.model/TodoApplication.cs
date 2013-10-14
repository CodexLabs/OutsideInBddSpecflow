using System.Collections.Generic;
using todoapp.model.core;

namespace todoapp.model
{
    public class TodoApplication
    {
        private readonly IHolidayCheckerService holidayCheck;

        public TodoApplication(IHolidayCheckerService holidayCheck)
        {
            this.holidayCheck = holidayCheck;
            TodoItems = new List<TodoItem>();
        }


        public void Add(TodoItem item)
        {
            if (!holidayCheck.IsHoliday())
            {
                if (!string.IsNullOrEmpty(item.Contents))
                {
                    TodoItems.Add(item);
                }
            }
        }

        public List<TodoItem> TodoItems { get; set; }
    }
}
