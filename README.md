# DateRangePicker Test

This application provides an example of encapsulating the logic of [Awio Web Services LLC's DateRangePicker](http://www.daterangepicker.com). It uses MVC EditorTemplates and a custom HTML Helper to allow you to add multiple DateRangePicker controls in a single view, as well as in multiple views.

## How to run the application

1. Clone the repository to your machine.
2. Open the DateRangePickerTest.sln file with Visual Studio. (It was written with Visual Studio 2017, but other versions likely work.)
3. Use the menu to browse to the Test Page view.
4. Complete the form and submit.
5. Review the information on the Review view.

## Anatomy 101

- `Views/Shared/_Layout.cshtml` contains the Link(CSS) and Script(JavaScript) tags to load the required libraries. The following are required for DateRangePicker to work:
  - The daterangepicker.css stylesheet
  - [JQuery](https://jquery.com)
  - [Moment.js](https://momentjs.com)
  - The daterangerpicker.js script library
- `Models/DateRange.cs` is used as a model for the data managed by the DateRangePicker. It contains the following properties:
  - `FullString`: The string representing the date range, as shown in the input control that is wired to the DateTimePicker.
  - `StartDateTime`: The start date and time that can be represented by a DateTime data type in C#.
  - `EndDateTime`: The end date and time that can be represented by a DateTime data type in C#.
- `Models/TestViewModel.cs` is the model for the `Views/Home/Test.cshtml` view. It has the following properties:
  - `SomeString`: Just a string property.
  - `SomeInt`: Just an integer property.
  - `SomeDateRange`: An instance of the DateRange class.
  - `SomeOtherDateRange`: Another instance of the DateRange class, to show how one view can work with two DateRange properties at once.
- `Views/Shared/EditorTemplates/DateRange.cshtml` provides an editor template that can be used to create the UI elements necessary for the DateTimePicker to work in the view, and be capable of posting its data to the controller action, binding to the DateRange model. The DateRange editor template renders three form elements:
  - A text input that will be wired up to the DateRangePicker using the jQuery extension method $.daterangepicker().
  - A hidden input that will keep track of the start date and time so that it can be posted back to the controller action and bound to the DateRange model's StartDateTime property.
  - A hidden input that will keep track of the end date and time so that it can be posted back to the controller action and bound to the DateRange model's EndDateTime property.
- `Helpers/HtmlHelperExtensions.cs` contains a static html helper extension method named `DateRangeJavaScriptFor()` that can be used to register the scripts that are necessary for the DateRangePicker to operate.

## How it all works

The DateRangePicker is a powerful JavaScript component, but it doesn't lend itself out-of-the-box to the server-side MVC architecture provided by ASP.NET MVC. Typically, a developer will use jQuery to wire up a single HTML text input element to the DateRangePicker. The value of this element stores a string that represents the date range. Although data attributes are used to store the actual start and end dates, data attributes don't get posted to the server by default when a form is submitted. This is where the hidden inputs help out. The JavaScript that is registered by our html helper detects changes in the text input, and copies values from the data attributes to the corresponding hidden fields. This way, the values will be included with the form data in the request body upon form submission.

## Try it out

I recommend putting a breakpoint in the `Test()` POST action of the `HomeController` to observe the `TestViewModel` after it reaches the server. You should see that ASP.NET MVC model-binding has done the heavy lifting for you, and you can worry about more important things... like beer.