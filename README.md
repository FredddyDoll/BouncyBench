# BouncyBench 🟡🪑

A playful and minimal MVVM Toolkit demo app where buttons bounce, commands run, and tests (occasionally) fail.

This repo is designed for **interviews**, **MVVM learning**, and **UI prototyping**. It uses:

* 🛠️ [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
* 💡 `RelayCommand`, `[ObservableProperty]`, and cancellation support
* 🪹 A bouncing button inside a canvas (with physics-lite simulation)
* 🧪 Unit tests for ViewModel behavior using xUnit

---

## 🏃 Getting Started

### Requirements

* .NET 6 or higher
* Visual Studio 2022 (or VS Code + C# Dev Kit)
* `Microsoft.Extensions.Logging.Console`

### Running

```bash
dotnet restore
dotnet run --project BouncyButton
```

Or open the solution in Visual Studio and press `F5`.

---

## 🧪 Running Tests

```bash
dotnet test
```

Test coverage includes:

* Boundary behavior (`StepSimulation`)
* Command execution (`RandomizeSpeed`)
* Command cancellation (`RunCommand`)
* Property change notifications

---

## 🧠 Discussion Topics (for interviews or learning)

### MVVM Toolkit Specifics

* How do `[ObservableProperty]` and `[RelayCommand]` work under the hood?
* What's the purpose of `[NotifyCanExecuteChangedFor]`?
* Why is `PropertyChanged` notification important for XAML bindings?

### Async + Cancellation

* How does the `RunCommand` loop respect `CancellationToken`?
* What happens if `Task.Delay` is replaced with something that throws?
* How would you test an async command properly?

### UI Binding Behavior

* What happens when `StepSizeLeft` is not bound?
* How do you test visual behavior in a non-visual unit test?
* When should you use `INotifyPropertyChanged` manually vs. generated code?

### Design Extensions

* Add configurable gravity or friction
* Make the button change color or shape when bouncing
* Introduce `ObservableValidator` to validate user input
* Add support for undo/redo of movement

### Test‐driven Development

* Modify a test to fail incorrectly—how do you spot a bad spec?
* Remove a `[NotifyPropertyChangedFor]` attribute—what UI breaks?
* Refactor bounce logic to eliminate duplication—how do you preserve test coverage?

---

## 🐙 Bonus Ideas

* Add a visual trail effect for the button
* Log movement using `ILogger` (already wired up)
* Animate multiple buttons, or spawn them on click
* Export movement path to a file (for later replay)

---

## License

MIT — bounce freely.
