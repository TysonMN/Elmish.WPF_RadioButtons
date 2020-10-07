using System;
using static ViewModel.Program;

namespace NoOpMessage.Views {
  public static class Program {
    [STAThread]
    public static void Main() =>
      main(new MainWindow());
  }
}