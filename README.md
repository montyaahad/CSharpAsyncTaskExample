CSharpAsyncTaskExample
======================
When we need something to run without interrupting the UI, we can use `Task` in .NET.

Lets see a simple code implementation -
```
using System.Threading.Tasks;
........
var task = Task.Factory.StartNew(() => MethodToExecute());

task.ContinueWith(t => AfterMethodExecuted(),
                  TaskScheduler.FromCurrentSynchronizationContext());

task.ContinueWith(t => HandleAnExceptionWhichTheTaskMayThrow(), 
                   TaskContinuationOptions.OnlyOnFaulted);
.........

void MethodToExecute()
{
  .....
}

void AfterMethodExecuted()
{
  .....
}

void HandleAnExceptionWhichTheTaskMayThrow()
{
  .....
}
```

Now, if we need to pass parameters on that method and after execution need to get the return value then -
```
class Student
{
    public string name { get; set; }
    public string roll { get; set; }
}
.......
Task<Student> task = Task.Factory.StartNew(() => MethodToExecute("Monty"));

task.ContinueWith(t => AfterMethodExecuted(task.Result),
      TaskScheduler.FromCurrentSynchronizationContext());
..........
Student MethodToExecute(string strName)
{
  return new Student(){name = strName, roll = "a-123"};
}

void AfterMethodExecuted(Student student)
{
  .....
}
```




