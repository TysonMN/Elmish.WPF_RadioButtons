using System;
using static ViewModel.Program;

namespace SetViaCommand.Views {
  public static class Program {
    [STAThread]
    public static void Main() =>
      main(new MainWindow());
  }
}